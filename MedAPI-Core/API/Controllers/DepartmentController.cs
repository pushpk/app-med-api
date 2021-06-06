using API.Controllers; using API.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;


namespace API.Controllers
{
   // [System.Web.Http.RoutePrefix("api/util")]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService departmentService;
        private readonly IUserService userService;
        public DepartmentController(IDepartmentService departmentService, IUserService userService)
        {
            this.departmentService = departmentService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("department/{query}")]
       public ActionResult Search(string query)
        {
           
            try
            {
                return Ok(departmentService.GetByName(query));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpGet]
        [Route("department")]
       public ActionResult GetAll()
        {
           
            try
            {
                return Ok(departmentService.GetAllDepartment());
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }
        [HttpGet]
        [Route("department/{id:int}")]
       public ActionResult Show(long id)
        {
           
            try
            {
                Department mDepartment = departmentService.GetDepartmentById(id);
                if (mDepartment == null)
                {
                  return NotFound("Requested entity was not found in database.");
                }
                else
                {
                    return Ok(mDepartment);
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpDelete]
        [Route("department/{id:int}")]
       public ActionResult Delete(long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    bool isSuccess = false;
                    isSuccess = departmentService.DeleteDepartmentById(id);
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

        [HttpPost]
        [Route("department")]
       public ActionResult Create(Department mDepartment)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mDepartment = departmentService.SaveDepartment(mDepartment);
                    return Ok(mDepartment);
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
        [Route("department/{id:int}")]
       public ActionResult Update(Department mDepartment, long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mDepartment.id = id;
                    mDepartment = departmentService.SaveDepartment(mDepartment);
                    return Ok(mDepartment);
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
