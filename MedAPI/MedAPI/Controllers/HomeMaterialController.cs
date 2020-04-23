using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/HomeMaterial")]
    public class HomeMaterialController : ApiController
    {
        private readonly IHomeMaterialService homeMaterialService;

        public HomeMaterialController(IHomeMaterialService homeMaterialService)
        {
            this.homeMaterialService = homeMaterialService;
        }

        [HttpGet]
        [Route("List")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, homeMaterialService.GetAllHomeMaterial());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
