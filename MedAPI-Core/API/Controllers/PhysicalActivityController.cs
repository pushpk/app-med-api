using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Services.IServices; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace API.Controllers
{
    public class PhysicalActivityController : BaseController
    {
        private readonly IPhysicalActivityService physicalActivityService;

        public PhysicalActivityController(IPhysicalActivityService physicalActivityService)
        {
            this.physicalActivityService = physicalActivityService;
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            
            try
            {
               return Ok(physicalActivityService.GetAllPhysicalActivity());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }
    }
}
