using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/Tickets")]
    public class TicketController : ApiController
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        [Route("ticket/{ticket}")]
        public HttpResponseMessage ticket(string ticket)
        {
            HttpResponseMessage response = null;
            try
            {
                string[] temp;
                string serie;
                string nro;
                temp = ticket.Split('-');
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
    }
}
