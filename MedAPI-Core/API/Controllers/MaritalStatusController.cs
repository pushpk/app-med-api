using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Controllers;   using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace API.Controllers
{
    
    public class MaritalStatusController : BaseController
    {
        private readonly IMaritalStatusService maritalStatusService;

        public MaritalStatusController(IMaritalStatusService maritalStatusService)
        {
            this.maritalStatusService = maritalStatusService;
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
           
            try
            {
               return Ok(maritalStatusService.GetAllMaritalStatus());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

    }
}
