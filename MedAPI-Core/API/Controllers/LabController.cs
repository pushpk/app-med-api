using Repository.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using API.Controllers;   using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Services.Helpers;
using static Services.Helpers.EmailHelper;
using Microsoft.AspNetCore.StaticFiles;

namespace API.Controllers
{

    [Route("api/users")]
    [Authorize]
    public class LabController : BaseController
    {
        private readonly ILabService labService;
        private readonly IUserService userService;
        private readonly IEmailService emailService;
        public LabController(ILabService labService, IUserService userService, IEmailService emailService)
        {
            this.labService = labService;
            this.userService = userService;
            this.emailService = emailService;
        }
       
        [HttpPost]
        [Route("lab")]
        [AllowAnonymous]
        public ActionResult Create(Lab mLab)
        {
            try
            {
                if (userService.IsUserAlreadyExist(mLab.user))
                {
                    return BadRequest("User Already Exist");
                    
                }

                mLab = labService.SaveLab(mLab);
                
                var emailConfirmationLink = SecurityHelper.GetEmailConfirmatioLink(mLab.user, Request);
                var emailBody = emailService.GetEmailBody(EmailPurpose.EmailVerification, emailConfirmationLink);
                emailService.SendEmailAsync(mLab.user.Email, "Verifique su Email - SolidarityMedical", emailBody, emailConfirmationLink);

               return Ok(mLab);
                //if (IsAdminPermission())
                //{
                   
                //}
                //else
                //{
                //   return Unauthorized();
                //}

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpPost]
        [Authorize(Roles = "lab, medic")]
        [Route("lab-upload-result")]
        public ActionResult Create()
        {
            var httpRequest = HttpContext.Request;
            var uploadedFile = httpRequest.Form.Files["uploadFile"];
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

            if (httpRequest.Form.Files.Count < 1)
            {
                return BadRequest();
                
            }
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(uploadedFile.OpenReadStream()))
            {
                fileData = binaryReader.ReadBytes(uploadedFile.ContentDisposition.Length);
            }
            var user = userService.GetUserById(int.Parse(userId));

            LabUploadResult uploadResult = new LabUploadResult
            {
                fileName = uploadedFile.FileName,
                fileContent = fileData,
                comments = comments,
                patient_docNumber = user.documentNumber,
                user_id = int.Parse(userId),
                labId = labId,
                medicId = medicId
            };

           
            try
            {
                uploadResult = labService.SaveUploadedFile(uploadResult);
                var labNotificationLink = SecurityHelper.GetLabNotificationLink(user, Request);
                var emailBody = emailService.GetEmailBody(EmailPurpose.PatientNotification);
                emailService.SendEmailAsync(user.Email, "New Upload From Lab", emailBody, labNotificationLink);
               return Ok(uploadResult);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Route("lab-uploads-by-lab-and-patient")]
        public ActionResult Get(int labId, int patientId)
        {
           
            try
            {
               return Ok(labService.GetAllUploadsByLabAndPatient(labId, patientId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          

        }

        [HttpGet]
        [Route("lab-uploads-by-patient")]
        public ActionResult GetByPatient(int patientId)
        {
           
            try
            {
               return Ok(labService.GetAllUploadsByPatient(patientId));
              
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          

        }

        [HttpPost]
        [Route("GetTestResultFile")]
        //download file api  
        public HttpResponseMessage GetFile()
        {
            var httpRequest = HttpContext.Request;
            int id = int.Parse(httpRequest.Form["id"].ToString());

            //Create HTTP Response.  
            HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };

            var uploadResult = this.labService.GetTestResultById(id);
            //Set the Response Content.  
            response.Content = new ByteArrayContent(uploadResult.fileContent);
            //Set the Response Content Length.  
            response.Content.Headers.ContentLength = uploadResult.fileContent.LongLength;
            //Set the Content Disposition Header Value and FileName.  
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = uploadResult.fileName + ".pdf";
            //Set the File Content Type.
            
            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(uploadResult.fileName + ".pdf", out contentType);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType ?? "application/octet-stream");

            return response;
          
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("freeze-lab")]
        public ActionResult FreezeLab(long id)
        {
            try
            {
                Lab mLab= labService.GetLab(id);

                mLab.IsFreezed = !mLab.IsFreezed;
                mLab = labService.UpdateLab(mLab);

                if (mLab == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mLab);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("approve-lab")]
        public ActionResult AprroveLab(long id)
        {
           
            try
            {
                Lab mLab = labService.GetLab(id);

                mLab.IsApproved = true;
                mLab.IsDenied = false;

                mLab = labService.UpdateLab(mLab);

                var emailBody = emailService.GetEmailBody(EmailPurpose.ApproveAccount);
                emailService.SendEmailAsync(mLab.user.Email, "Laboratorio Aprobado -  SolidarityMedical", emailBody);


                if (mLab == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mLab);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("deny-lab")]
        public ActionResult DenyLab(long id)
        {
           
            try
            {
                Lab mLab = labService.GetLab(id);

                mLab.IsDenied = true;
                mLab.IsApproved = false;
                mLab = labService.UpdateLab(mLab);
                var emailBody = emailService.GetEmailBody(EmailPurpose.DenyAccount);
                emailService.SendEmailAsync(mLab.user.Email, "Laboratorio Denegado - SolidarityMedical", emailBody);

                if (mLab == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mLab);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }


        private bool IsAdminPermission()
        {
            bool result = false;
            var email = Request.Headers["email"].ToString();
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
