using API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace API.Controllers
{
    //[System.Web.Http.RoutePrefix("api/BloodType")]
    public class BloodTypeController : BaseController
    {
        private readonly IBloodTypeService bloodTypeService;

        public BloodTypeController(IBloodTypeService bloodTypeService)
        {
            this.bloodTypeService = bloodTypeService;
        }

        [HttpGet]
        public ActionResult List()
        {
            try
            {
                return Ok(bloodTypeService.GetAllBloodType());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
            
        }
    }

}
