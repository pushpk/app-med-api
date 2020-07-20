using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("upload")]
    public class ApplicationController : ApiController
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
        public HttpResponseMessage Upload(Domain.Upload mUpload)
        {
            HttpResponseMessage response = null;
            try
            {
                mUpload.createdBy = GetCuurentUser();
                response = Request.CreateResponse(HttpStatusCode.OK, applicationService.SaveFile(mUpload));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "File not uploaded");
            }
            return response;
        }

        public string GetCuurentUser()
        {
            var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            string email = Convert.ToString(headerValues.FirstOrDefault());
            return email;
        }
    }
}
