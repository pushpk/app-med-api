using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using static MedAPI.Infrastructure.EmailHelper;

namespace MedAPI.Controllers
{

    [System.Web.Http.RoutePrefix("api/users")]
    [Authorize]
    public class MedicController : ApiController
    {
        private readonly IMedicService medicService;
        private readonly IUserService userService;
        private readonly IEmailService emailService;
        public MedicController(IMedicService medicService, IUserService userService, IEmailService emailService)
        {
            this.medicService = medicService;
            this.userService = userService;
            this.emailService = emailService;
    }
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("medic")]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, medicService.GetAllMedic());
                //if(IsAdminPermission())
                //   response = Request.CreateResponse(HttpStatusCode.OK, medicService.GetAllMedic());
                //else
                //    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("medic/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Medic mMedic = medicService.GetMedicById(id);
                if (mMedic == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mMedic);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("get-medic")]
        public HttpResponseMessage GetMedicId(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Medic mMedic = medicService.GetMedicById(id);
                if (mMedic == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mMedic);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("freeze-medic")]
        public HttpResponseMessage FreezeMedic(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Medic mMedic = medicService.GetMedicById(id);

                mMedic.IsFreezed = !mMedic.IsFreezed;
                mMedic = medicService.UpdateMedic(mMedic);

                if (mMedic == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mMedic);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("approve-medic")]
        public HttpResponseMessage AprroveMedic(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Medic mMedic = medicService.GetMedicById(id);

                mMedic.IsApproved = true;
                mMedic.IsDenied = false;
                mMedic = medicService.UpdateMedic(mMedic);
                var emailBody = emailService.GetEmailBody(EmailPurpose.ApproveAccount);
                //emailService.SendEmailAsync(mMedic.user.email, "Medic Approved -  MedAPI", emailBody);
                emailService.SendEmailAsync(mMedic.user.email, "Cuenta Aprobada - SolidarityMedical", emailBody);

                if (mMedic == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mMedic);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("deny-medic")]
        public HttpResponseMessage DenyMedic(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Medic mMedic = medicService.GetMedicById(id);

                mMedic.IsDenied = true;
                mMedic.IsApproved = false;
                mMedic = medicService.UpdateMedic(mMedic);
                var emailBody = emailService.GetEmailBody(EmailPurpose.DenyAccount);
                emailService.SendEmailAsync(mMedic.user.email, "Cuenta Denegada - SolidarityMedical", emailBody);

                if (mMedic == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mMedic);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("medic/{id:int}")]
        public HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    bool isSuccess = false;
                    isSuccess = medicService.DeleteMedicById(id);
                    if (isSuccess)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, "Entity removed successfully.");
                    }
                    else
                        response = Request.CreateResponse(HttpStatusCode.OK, "Invalid Entity. Not found");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("medic")]
        public HttpResponseMessage Create(Domain.Medic mMedic)
        {
            HttpResponseMessage response = null;

            if (userService.IsUserAlreadyExist(mMedic.user, mMedic.cmp))
            {
                response = Request.CreateResponse(HttpStatusCode.Conflict, "User Already Exist");
            }
            else
            {
                try
                {
                    mMedic = medicService.SaveMedic(mMedic);

                    var emailConfirmationLink = Infrastructure.SecurityHelper.GetEmailConfirmatioLink(mMedic.user, Request);
                    var emailBody = emailService.GetEmailBody(EmailPurpose.EmailVerification, emailConfirmationLink);
                    emailService.SendEmailAsync(mMedic.user.email, "Verificacion de Email - SolidarityMedical", emailBody, emailConfirmationLink);


                    response = Request.CreateResponse(HttpStatusCode.OK, mMedic);


                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            return response;
        }
        [HttpPost]
        [Route("medic/{id:int}")]
        public HttpResponseMessage Update(Domain.Medic mMedic, long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mMedic.user.id = id;
                    mMedic = medicService.SaveMedic(mMedic);
                    response = Request.CreateResponse(HttpStatusCode.OK, mMedic);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
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
