using Services.IServices; using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using API.Controllers;
using Repository.DTOs;

namespace API.Controllers
{
    [Route("api/util")]
    public class ProvinceController : BaseController
    {
        private readonly IProvinceService provinceService;
        private readonly IUserService userService;
        public ProvinceController(IProvinceService provinceService, IUserService userService)
        {
            this.provinceService = provinceService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("province/{query?}/{department:int?}")]
        public ActionResult Search(string query=null,int department=0)
        {
            
            try
            {
               return Ok(provinceService.Search(query, department));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }
        [HttpGet]
        [Route("province")]
        public ActionResult GetAll()
        {
            
            try
            {
               return Ok(provinceService.GetAllProvince());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpPost]
        [Route("province")]
        public ActionResult Create(Province mProvince)
        {
            
            try
            {
                if (IsAdminPermission())
                {
                    mProvince = provinceService.SaveProvince(mProvince);
                   return Ok(mProvince);
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
        [Route("province/{id:int}")]
        public ActionResult Update(Province mProvince,long id)
        {
            
            try
            {
                if (IsAdminPermission())
                {
                    mProvince.id = id;
                    mProvince = provinceService.SaveProvince(mProvince);
                   return Ok(mProvince);
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
        [Route("province/{id:int}")]
        public ActionResult Show(long id)
        {
            
            try
            {
                Province mProvince = provinceService.GetProvinceById(id);
                if (mProvince == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mProvince);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpDelete]
        [Route("province/{id:int}")]
        public ActionResult Delete(long id)
        {
            
            try
            {
                if (IsAdminPermission())
                {
                    bool isSuccess = false;
                    isSuccess = provinceService.DeleteProvinceById(id);
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
