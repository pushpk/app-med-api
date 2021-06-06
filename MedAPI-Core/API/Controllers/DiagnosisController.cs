using API.Controllers; 
using Services.IServices;
using System;
 using Repository.DTOs;  using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Web;

using System.Linq;
using System.Net;

namespace API.Controllers
{
    //[System.Web.Http.RoutePrefix("api/admin")]
    public class DiagnosisController : BaseController
    {
        private readonly IDiagnosisService diagnosisService;
        private readonly IUserService userService;

        public DiagnosisController(IDiagnosisService diagnosisService,IUserService userService)
        {
            this.diagnosisService = diagnosisService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("diagnosis")]
       public ActionResult Search(string query="")
        {
           
            try
            {
                return Ok(diagnosisService.SearchByNameOrCode(query));
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        //[HttpGet]
        //[Route("diagnosis")]
        //public HttpResponseMessage List()
        //{
        //   
        //    try
        //    {
        //        return Ok(diagnosisService.GetAllDiagnosis());
        //    }
        //    catch (Exception ex)
        //    {
        //         return StatusCode(500, ex.Message.ToString());
        //    }
        //   
        //}

        [HttpGet]
        [Route("diagnosis/{id:int}")]
       public ActionResult Show(long id)
        {
           
            try
            {
                Repository.DTOs.Diagnosis mDiagnosis = diagnosisService.GetDiagnosisById(id);
                if (mDiagnosis == null)
                {
                  return NotFound("Requested entity was not found in database.");
                }
                else
                {
                    return Ok(mDiagnosis);
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           

        }

        [HttpPost]
        [Route("diagnosis")]
       public ActionResult Create(Diagnosis mDiagnosis)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    int id = diagnosisService.SaveDiagnosis(mDiagnosis);

                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        //Forbidden
                        return StatusCode(403);
                        
                    }
                }else
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpPost]
        [Route("diagnosis/{id:int}")]
       public ActionResult Update(Diagnosis mDiagnosis,long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mDiagnosis.id = id;
                     id = diagnosisService.SaveDiagnosis(mDiagnosis);

                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        //Forbidden
                        return StatusCode(403);
                    }
                }
                else
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpDelete]
        [Route("diagnosis/{id:int}")]
       public ActionResult Delete(long id)
        {
           
            try
            {
                bool isSuccess = false;
                isSuccess = diagnosisService.DeleteDiagnosisById(id);
                if (isSuccess)
                {
                    return Ok("Entity removed successfully.");
                }
                else
                {
                    return StatusCode(500);
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


