using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
 using Repository.DTOs;  using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using API.Controllers;

namespace API.Controllers
{
    //[System.Web.Http.RoutePrefix("api/DocumentType")]
    public class DocumentTypeController : BaseController
    {
        private readonly IDocumentTypeService documentTypeService;

        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            this.documentTypeService = documentTypeService;
        }

        [HttpGet]
        [Route("List")]
       public ActionResult List()
        {
           
            try
            {
                return Ok(documentTypeService.GetAllDocumentType());
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }
    }
}
