using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
 using Repository.DTOs;  using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using API.Controllers;

namespace API.Controllers
{
    //[System.Web.Http.RoutePrefix("api/Education")]
    public class EducationController : BaseController
    {
        private readonly IEducationService educationService;

        public EducationController(IEducationService educationService)
        {
            this.educationService = educationService;
        }

        [HttpGet]
        [Route("List")]
       public ActionResult List()
        {
           
            try
            {
                return Ok(educationService.GetAllEducation());
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }
    }
}
