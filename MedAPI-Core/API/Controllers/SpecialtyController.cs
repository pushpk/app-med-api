using Services.IServices; using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Controllers;

namespace API.Controllers
{
    [Route("api/record")]
    public class SpecialtyController : BaseController
    {
        private readonly ISpecialtyService specialtyService;

        public SpecialtyController(ISpecialtyService specialtyService)
        {
            this.specialtyService = specialtyService;
        }

        [HttpGet]
        [Route("specialty")]
        public ActionResult Search(string query="")
        {
            
            try
            {
               return Ok(specialtyService.SearchByName(query));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        //[HttpGet]
        //[Route("specialty")]
        //public ActionResult List()
        //{
        //    
        //    try
        //    {
        //       return Ok(specialtyService.GetAllSpecialty());
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message.ToString());
        //    }
        //   
        //}

    }
}
