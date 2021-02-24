using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/Triage")]
    [Authorize]
    public class TriageController : ApiController
    {
        private readonly ITriageService triageService;
        public TriageController(ITriageService triageService)
        {
            this.triageService = triageService;
        }
        [HttpPost]
        [Route("GetLatest")]
        public HttpResponseMessage GetLatest(Domain.Patient mPatient)
        {
            HttpResponseMessage response = null;
            try
            {
                Domain.Triage mTriage = triageService.GetLatest(mPatient);
                if (mTriage == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mTriage);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return response;
        }
    }
}
