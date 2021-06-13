using Repository.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using API.Controllers;   using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/users")]
    public class NurseController : BaseController
    {
        private readonly INurseService nurseService;
        private readonly IUserService userService;
        public NurseController(INurseService nurseService, IUserService userService)
        {
            this.nurseService = nurseService;
            this.userService = userService;
        }
        [HttpGet]
        [Route("nurse")]
        public ActionResult GetAll()
        {
           
            try
            {
               return Ok(nurseService.GetAll());
                //if (IsAdminPermission())
                //{
                //   return Ok(nurseService.GetAll());
                //}
                //else
                //{
                //   return Unauthorized();
                //}
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Route("nurse/{id:int}")]
        public ActionResult Show(long id)
        {
           
            try
            {
                Nurse mNurse = nurseService.GetNurseById(id);
                if (mNurse == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mNurse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }



        [HttpPost]
        [Route("nurse")]
        public ActionResult Create(Nurse mNurse)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mNurse = nurseService.SaveNurse(mNurse);
                   return Ok(mNurse);
                }
                else
                {
                   return Unauthorized();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpPost]
        [Route("nurse/{id:int}")]
        public ActionResult Update(Nurse mNurse,long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mNurse.user.Id = id;
                    mNurse = nurseService.SaveNurse(mNurse);
                   return Ok(mNurse);
                }
                else
                {
                   return Unauthorized();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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
