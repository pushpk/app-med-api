﻿using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/DocumentType")]
    public class DocumentTypeController : ApiController
    {
        private readonly IDocumentTypeService documentTypeService;

        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            this.documentTypeService = documentTypeService;
        }

        [HttpGet]
        [Route("List")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, documentTypeService.GetAllDocumentType());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
    }
}
