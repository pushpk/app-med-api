using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
 using Repository.DTOs;  using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using API.Controllers;

namespace API.Controllers
{

    //[System.Web.Http.RoutePrefix("api/Email")]
    public class EmailController : BaseController
    {
        private readonly IEmailService emailService;
        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost]
        [Route("SendEmail")]
       public ActionResult sendEmail(string email, string subject, string body)
        {
           
            try
            {
                //return Ok(emailService.SendEmail());
                return Ok(emailService.SendEmailAsync(email, subject, body));
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }
    }
}
