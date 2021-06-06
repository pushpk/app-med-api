using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Controllers;   using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[System.Web.Http.RoutePrefix("api/HomeMaterial")]
    public class HomeMaterialController : BaseController
    {
        private readonly IHomeMaterialService homeMaterialService;

        public HomeMaterialController(IHomeMaterialService homeMaterialService)
        {
            this.homeMaterialService = homeMaterialService;
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
           
            try
            {
                return Ok(homeMaterialService.GetAllHomeMaterial());
               
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
          
        }
    }
}
