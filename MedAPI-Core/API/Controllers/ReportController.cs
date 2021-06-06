using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/note")]
    public class ReportController : BaseController
    {
        [HttpGet]
        [Route("{id:int}/report/note")]
        public ActionResult NoteReport(long id)
        {
            
            try
            {
               return Ok("");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }
        [HttpGet]
        [Route("{id:int}/report/prescription")]
        public ActionResult NotePrescription(long id)
        {
            
            try
            {
               return Ok("");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpGet]
        [Route("{id:int}/report/specialty")]
        public ActionResult NoteSpecialty(long id)
        {
            
            try
            {
               return Ok("");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }
        [HttpGet]
        [Route("{id:int}/report/image")]
        public ActionResult NoteImage(long id)
        {
            
            try
            {
               return Ok("");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpGet]
        [Route("{id:int}/report/laboratory")]
        public ActionResult NoteLaboratory(long id)
        {
            
            try
            {
               return Ok("");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpGet]
        [Route("{id:int}/report/ginecology")]
        public ActionResult NoteGinecology(long id)
        {
            
            try
            {
               return Ok("");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        

    }
}
