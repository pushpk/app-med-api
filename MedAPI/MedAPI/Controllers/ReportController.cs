using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("")]
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("note/{id:int}/report/note")]
        public HttpResponseMessage NoteReport(long id)
        {
            HttpResponseMessage response = null;
            try
            {
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("note/{id:int}/report/prescription")]
        public HttpResponseMessage NotePrescription(long id)
        {
            HttpResponseMessage response = null;
            try
            {
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("note/{id:int}/report/specialty")]
        public HttpResponseMessage NoteSpecialty(long id)
        {
            HttpResponseMessage response = null;
            try
            {
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("note/{id:int}/report/image")]
        public HttpResponseMessage NoteImage(long id)
        {
            HttpResponseMessage response = null;
            try
            {
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("note/{id:int}/report/laboratory")]
        public HttpResponseMessage NoteLaboratory(long id)
        {
            HttpResponseMessage response = null;
            try
            {
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("note/{id:int}/report/ginecology")]
        public HttpResponseMessage NoteGinecology(long id)
        {
            HttpResponseMessage response = null;
            try
            {
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("note/{id:int}/report/cardiology")]
        public HttpResponseMessage NoteCardiology(long id)
        {
            HttpResponseMessage response = null;
            try
            {
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

    }
}
