using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/HomeOwnership")]
    public class HomeOwnershipController : ApiController
    {
        private readonly IHomeOwnershipService homeOwnershipService;

        public HomeOwnershipController(IHomeOwnershipService homeOwnershipService)
        {
            this.homeOwnershipService = homeOwnershipService;
        }

        [HttpGet]
        [Route("List")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, homeOwnershipService.GetAllHomeOwnership());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
