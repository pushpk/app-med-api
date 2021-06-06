using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
 using Repository.DTOs;  using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Web;
using API.Controllers;

namespace API.Controllers
{
   // [System.Web.Http.RoutePrefix("api/util")]
    public class EstablishmentController : BaseController
    {
        private readonly IEstablishmentService establishmentService;
        private readonly IUserService userService;
        public EstablishmentController(IEstablishmentService establishmentService, IUserService userService)
        {
            this.establishmentService = establishmentService;
            this.userService = userService;
        }
        [HttpGet]
        [Route("establishment")]
       public ActionResult GetAll()
        {
           
            try
            {
                return Ok(establishmentService.GetAllEstablishment());
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpPost]
        [Route("establishment")]
       public ActionResult Create(Establishment mEstablishment)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mEstablishment = establishmentService.SaveEstablishment(mEstablishment);
                    return Ok(mEstablishment);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }
        [HttpPost]
        [Route("establishment/{id:int}")]
       public ActionResult Update(Establishment mEstablishment,long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mEstablishment.id = id;
                    mEstablishment = establishmentService.SaveEstablishment(mEstablishment);
                    return Ok(mEstablishment);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }
        [HttpGet]
        [Route("establishment/{id:int}")]
       public ActionResult Show(long id)
        {
           
            try
            {
                Establishment mEstablishment = establishmentService.GetEstablishmentById(id);
                if (mEstablishment == null)
                {
                  return NotFound("Requested entity was not found in database.");
                }
                else
                {
                    return Ok(mEstablishment);
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpDelete]
        [Route("establishment/{id:int}")]
       public ActionResult Delete(long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    bool isSuccess = false;
                    isSuccess = establishmentService.DeleteEstablishmentById(id);
                    if (isSuccess)
                    {
                        return Ok("Entity removed successfully.");
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           

        }

        private bool IsAdminPermission()
        {
            bool result = false;
            var email = Request.Headers["email"].ToString();
            var user = userService.GetByEmail(email);
            if (user != null)
            {
                if (user.roleId == (int)Infrastructure.Common.Permission.ADMIN)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
