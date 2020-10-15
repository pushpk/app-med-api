using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace MedAPI.Controllers
{

    [System.Web.Http.RoutePrefix("users")]
    public class LabController : ApiController
    {
        private readonly ILabService labService;
        private readonly IUserService userService;
        public LabController(ILabService labService, IUserService userService)
        {
            this.labService = labService;
            this.userService = userService;
        }
       
        [HttpPost]
        [Route("lab")]
        public HttpResponseMessage Create(Domain.Lab mLab)
        {
            HttpResponseMessage response = null;
            try
            {
                mLab = labService.SaveLab(mLab);
                response = Request.CreateResponse(HttpStatusCode.OK, mLab);
                //if (IsAdminPermission())
                //{
                   
                //}
                //else
                //{
                //    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
                //}

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("lab-upload-result")]
        public HttpResponseMessage Create()
        {
            var httpRequest = HttpContext.Current.Request;
            var uploadedFile = httpRequest.Files["uploadFile"];
            string comments = httpRequest.Form["comments"];
            string userId = httpRequest.Form["userId"];
            int? labId =   null;
            int? medicId = null;

            if (string.IsNullOrEmpty(httpRequest.Form["labId"]) || httpRequest.Form["labId"].ToString() == "null")
            {
                labId = null;
            }
            else
            {
                labId = int.Parse(httpRequest.Form["labId"].ToString());
            }

            if (string.IsNullOrEmpty(httpRequest.Form["medicId"]) || httpRequest.Form["medicId"].ToString() == "null")
            {
                medicId = null;
            }
            else
            {
                medicId = int.Parse(httpRequest.Form["medicId"].ToString());
            }

            if (httpRequest.Files.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(uploadedFile.InputStream))
            {
                fileData = binaryReader.ReadBytes(uploadedFile.ContentLength);
            }

            LabUploadResult uploadResult = new LabUploadResult
            {
                fileName = uploadedFile.FileName,
                fileContent = fileData,
                comments = comments,
                user_id = int.Parse(userId),
                labId = labId,
                medicId = medicId
            };

            HttpResponseMessage response = null;
            try
            {
                uploadResult = labService.SaveUploadedFile(uploadResult);
                response = Request.CreateResponse(HttpStatusCode.OK, uploadResult);
                
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("lab-uploads-by-lab")]
        public HttpResponseMessage Get(int labId)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, labService.GetAllUploadsByLab(labId));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;

        }

        [HttpGet]
        [Route("lab-uploads-by-patient")]
        public HttpResponseMessage GetByPatient(int patientId)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, labService.GetAllUploadsByPatient(patientId));
              
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;

        }

        [HttpPost]
        [Route("GetTestResultFile")]
        //download file api  
        public HttpResponseMessage GetFile()
        {
            var httpRequest = HttpContext.Current.Request;
            int id = int.Parse(httpRequest.Form["id"].ToString());


            //Create HTTP Response.  
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);


            var uploadResult = this.labService.GetTestResultById(id);
            //Set the Response Content.  
            response.Content = new ByteArrayContent(uploadResult.fileContent);
            //Set the Response Content Length.  
            response.Content.Headers.ContentLength = uploadResult.fileContent.LongLength;
            //Set the Content Disposition Header Value and FileName.  
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = uploadResult.fileName + ".pdf";
            //Set the File Content Type.  
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(uploadResult.fileName + ".pdf"));
            return response;
        }


        public bool IsAdminPermission()
        {
            bool result = false;
            var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            string email = Convert.ToString(headerValues.FirstOrDefault());
            var user = userService.GetByEmail(email);
            if (user != null)
            {
                if (user.roleId == (int)Infrastructure.Common.Permission.ADMIN)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
