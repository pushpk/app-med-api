using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedAPI.Infrastructure.IService;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/MaritalStatus")]
    public class MaritalStatusController : ApiController
    {
        private readonly IMaritalStatusService maritalStatusService;

        public MaritalStatusController(IMaritalStatusService maritalStatusService)
        {
            this.maritalStatusService = maritalStatusService;
        }

        [HttpGet]
        [Route("List")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, maritalStatusService.GetAllMaritalStatus());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

    }
}
