
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService applicationService;
        private readonly IUserService userService;
        public ApplicationController(IApplicationService applicationService, IUserService userService)
        {
            this.applicationService = applicationService;
            this.userService = userService;
        }

        [HttpPost]
        [Route("upload")]
       public ActionResult Upload(Upload mUpload)
        {
           
            try
            {
                mUpload.createdBy = GetCuurentUser();
                applicationService.SaveFile(mUpload);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                
            }
            
        }

        [HttpGet]
        public string GetCuurentUser()
        {
            
            return Request.Headers["email"].ToString();
            
        }
    }
}
