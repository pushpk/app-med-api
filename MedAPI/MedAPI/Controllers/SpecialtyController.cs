using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("record")]
    public class SpecialtyController : ApiController
    {
        private readonly ISpecialtyService specialtyService;

        public SpecialtyController(ISpecialtyService specialtyService)
        {
            this.specialtyService = specialtyService;
        }

        [HttpGet]
        [Route("specialty/{query?}")]
        public HttpResponseMessage Search(string query="")
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, specialtyService.SearchByName(query));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("specialty")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, specialtyService.GetAllSpecialty());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

    }
}
