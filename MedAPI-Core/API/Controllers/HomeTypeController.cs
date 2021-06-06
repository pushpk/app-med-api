using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Controllers;   using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class HomeTypeController : BaseController
    {
        private readonly IHomeTypeService homeTypeService;

        public HomeTypeController(IHomeTypeService homeTypeService)
        {
            this.homeTypeService = homeTypeService;
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
           
            try
            {
               return Ok(homeTypeService.GetAllHomeType());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }
    }
}
