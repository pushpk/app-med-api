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
    //[System.Web.Http.RoutePrefix("api/util")]
    public class DistrictController : BaseController
    {
        private readonly IDistrictService districtService;
        private readonly IUserService userService;
        public DistrictController(IDistrictService districtService, IUserService userService)
        {
            this.districtService = districtService;
            this.userService = userService;
        }
        [HttpGet]
        [Route("district")]
       public ActionResult GetAll()
        {
           
            try
            {
                return Ok(districtService.GetAllDistrict());
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpPost]
        [Route("district")]
       public ActionResult Create(District mDistrict)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mDistrict = districtService.SaveDistrict(mDistrict);
                    return Ok(mDistrict);
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
        [Route("district/{id:int}")]
       public ActionResult Update(District mDistrict,long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mDistrict.id = id;
                    mDistrict = districtService.SaveDistrict(mDistrict);
                    return Ok(mDistrict);
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
        [Route("district/{id:int}")]
       public ActionResult Show(long id)
        {
           
            try
            {
                District mDistrict = districtService.GetDistrictById(id);
                if (mDistrict == null)
                {
                  return NotFound("Requested entity was not found in database.");
                }
                else
                {
                    return Ok(mDistrict);
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpDelete]
        [Route("district/{id:int}")]
       public ActionResult Delete(long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    bool isSuccess = false;
                    isSuccess = districtService.DeleteDistrictById(id);
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
