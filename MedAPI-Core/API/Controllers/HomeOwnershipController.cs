using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Controllers;   using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[System.Web.Http.RoutePrefix("api/HomeOwnership")]
    
    public class HomeOwnershipController : BaseController
    {
        private readonly IHomeOwnershipService homeOwnershipService;

        public HomeOwnershipController(IHomeOwnershipService homeOwnershipService)
        {
            this.homeOwnershipService = homeOwnershipService;
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
           
            try
            {
               return Ok(homeOwnershipService.GetAllHomeOwnership());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }
    }
}
