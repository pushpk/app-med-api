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
    public class TicketController : ApiController
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        [Route("ticket/{id}")]
        public HttpResponseMessage ticket(string id)
        {
            HttpResponseMessage response = null;
            try
            {
                string[] temp;
                string serie;
                string nro;
                temp = id.Split('-');
                if (temp.Length == 2)
                {
                    serie = temp[0];
                    nro = temp[1];
                    response = Request.CreateResponse(HttpStatusCode.OK, ticketService.getByTicket(serie,nro));
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest,"bad request");
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("patient/{documentNumber}")]
        public HttpResponseMessage GetPatientByDocumentNumber(string documentNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                // response = Request.CreateResponse(HttpStatusCode.OK, patientService.GetPatientByDocumentNumber(documentNumber));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
