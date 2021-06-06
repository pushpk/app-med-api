using API.Controllers; using API.Models;
using Services.IServices;
using System;
using System.Linq;
 using Repository.DTOs;  using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Web;


namespace API.Controllers
{
    //[System.Web.Http.RoutePrefix("api/admin")]
    public class ExamController : BaseController
    {
        private readonly IExamService examService;
        private readonly IUserService userService;

        public ExamController(IExamService examService, IUserService userService)
        {
            this.examService = examService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("exam")]
       public ActionResult Search(string query="")
        {
           
            try
            {
                return Ok(examService.SearchByName(query));
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        //[HttpGet]
        //[Route("exam")]
        //public HttpResponseMessage List()
        //{
        //   
        //    try
        //    {
        //        return Ok(examService.GetAllExam());
        //    }
        //    catch (Exception ex)
        //    {
        //         return StatusCode(500, ex.Message.ToString());
        //    }
        //   
        //}

        [HttpGet]
        [Route("exam/{id:int}")]
       public ActionResult Show(long id)
        {
           
            try
            {
                Exam mExam = examService.GetExamById(id);
                if (mExam == null)
                {
                  return NotFound("Requested entity was not found in database.");
                }
                else
                    return Ok(mExam);
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           

        }

        [HttpPost]
        [Route("exam")]
       public ActionResult Create(Exam mExam)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    int id = examService.SaveExam(mExam);

                    if (id > 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return StatusCode(500);
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

        [HttpPost]
        [Route("exam/{id:int}")]
       public ActionResult Update(Exam mExam,long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mExam.id = id;
                    id = examService.SaveExam(mExam);

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
        [Route("exam/{id:int}")]
       public ActionResult Delete(long id)
        {
           
            try
            {
                bool isSuccess = false;
                isSuccess = examService.DeleteExamById(id);
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
