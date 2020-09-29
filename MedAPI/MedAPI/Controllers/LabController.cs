using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MedAPI.Controllers
{

    [System.Web.Http.RoutePrefix("users")]
    public class LabController : ApiController
    {
        private readonly ILabService labService;
        private readonly IUserService userService;
        public LabController(ILabService labService, IUserService userService)
        {
            this.labService = labService;
            this.userService = userService;
        }
       
        [HttpPost]
        [Route("lab")]
        public HttpResponseMessage Create(Domain.Lab mLab)
        {
            HttpResponseMessage response = null;
            try
            {
                mLab = labService.SaveLab(mLab);
                response = Request.CreateResponse(HttpStatusCode.OK, mLab);
                //if (IsAdminPermission())
                //{
                   
                //}
                //else
                //{
                //    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
                //}

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
       
        public bool IsAdminPermission()
        {
            bool result = false;
            var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            string email = Convert.ToString(headerValues.FirstOrDefault());
            var user = userService.GetByEmail(email);
            if (user != null)
            {
                if (user.roleId == (int)Infrastructure.Common.Permission.ADMIN)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
