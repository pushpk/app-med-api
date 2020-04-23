using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/PhysicalActivity")]
    public class PhysicalActivityController : ApiController
    {
        private readonly IPhysicalActivityService physicalActivityService;

        public PhysicalActivityController(IPhysicalActivityService physicalActivityService)
        {
            this.physicalActivityService = physicalActivityService;
        }

        [HttpGet]
        [Route("List")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, physicalActivityService.GetAllPhysicalActivity());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
