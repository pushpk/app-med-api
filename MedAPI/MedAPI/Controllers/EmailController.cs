using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{

    [System.Web.Http.RoutePrefix("api/Email")]
    public class EmailController : ApiController
    {
        private readonly IEmailService emailService;
        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost]
        [Route("SendEmail")]
        public HttpResponseMessage sendEmail(string email, string subject, string body)
        {
            HttpResponseMessage response = null;
            try
            {
                //response = Request.CreateResponse(HttpStatusCode.OK, emailService.SendEmail());
                response = Request.CreateResponse(HttpStatusCode.OK, emailService.SendEmailAsync(email, subject, body));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
