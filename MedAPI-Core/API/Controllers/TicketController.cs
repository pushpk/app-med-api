using Services.IServices; using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Controllers;

namespace API.Controllers
{
    [Route("api/record")]
    public class TicketController : BaseController
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        [Route("ticket/{id}")]
        public ActionResult ticket(string id)
        {
            
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
                   return Ok(ticketService.getByTicket(serie,nro));
                }
                else
                {
                    return BadRequest();
                    
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
           
        }

        [HttpGet]
        [Route("patient/{documentNumber}")]
        public ActionResult GetPatientByDocumentNumber(string documentNumber)
        {
            
            try
            {
                return Ok();
                //return Ok(patientService.GetPatientByDocumentNumber(documentNumber));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }
    }
}
