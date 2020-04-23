using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/HomeType")]
    public class HomeTypeController : ApiController
    {
        private readonly IHomeTypeService homeTypeService;

        public HomeTypeController(IHomeTypeService homeTypeService)
        {
            this.homeTypeService = homeTypeService;
        }

        [HttpGet]
        [Route("List")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, homeTypeService.GetAllHomeType());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
