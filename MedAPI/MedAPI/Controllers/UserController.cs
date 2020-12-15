using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using static MedAPI.Infrastructure.EmailHelper;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("users")]
    public class UserController : ApiController
    {
        private readonly IUserService userService;
        private readonly IEmailService emailService;
        private readonly IMedicService medicService;

        public UserController(IUserService userService, IEmailService emailService, IMedicService medicService)
        {
            this.userService = userService;
            this.emailService = emailService;
            this.medicService = medicService;
        }

        [HttpGet]
        [Route("users")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, userService.GetAllUser());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("not-approved-medics")]
        public HttpResponseMessage GetAllNonApprovedMedics()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, userService.GetAllNonApprovedMedics());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("not-approved-labs")]
        public HttpResponseMessage GetAllNonApprovedLabs()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, userService.GetAllNonApprovedLabs());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("users/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                User mUser = userService.GetUserById(id);
                if (mUser == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mUser);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpDelete]
        [Route("users/{id:int}")]
        public HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                bool isSuccess = false;
                isSuccess = userService.DeleteUserById(id);
                if (isSuccess)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, "Entity removed successfully.");
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;

        }


        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(Domain.User mUser, string currentUrl)
        {
            HttpResponseMessage response = null;
            try
            {
                mUser = userService.SaveUser(mUser);

                var emailVerificationLink = Infrastructure.SecurityHelper.GetEmailConfirmatioLink(mUser, Request);
                var emailBody = emailService.GetEmailBody(EmailPurpose.EmailVerification, emailVerificationLink);
                emailService.SendEmailAsync(mUser.email, "Confirm Email - MedAPI", emailBody, emailVerificationLink);

                response = Request.CreateResponse(HttpStatusCode.OK, mUser);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpPost]
        [Route("users/{id:int}")]
        public HttpResponseMessage Update(Domain.User mUser, long id)
        {
            HttpResponseMessage response = null;
            try
            {
                mUser.id = id;
                mUser = userService.SaveUser(mUser);
                response = Request.CreateResponse(HttpStatusCode.OK, mUser);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("resources")]
        public HttpResponseMessage Resources()
        {
            HttpResponseMessage response = null;
            Domain.UserResources mUserResources = new UserResources();
            try
            {
                mUserResources = userService.GetResources();
                response = Request.CreateResponse(HttpStatusCode.OK, mUserResources);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpPost]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("login")]
        public HttpResponseMessage authenticate(Domain.Login mLogin)
        {
            Domain.User mUser = new Domain.User();

            HttpResponseMessage response = null;
            try
            {
                mUser = userService.Authenticate(mLogin.username, mLogin.Password);

                if (mUser != null)
                {
                    if (!mUser.emailConfirmed)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { message = "Email_Not_Confirmed" });
                    }


                    IEnumerable<string> permissions;
                    using (var ctx = new DataAccess.registroclinicoEntities())
                    {
                        permissions = ctx.role_permissions.Where(s => s.Role_id == mUser.roleId).Select(s => s.permissions).ToArray();

                        var medic = this.medicService.GetMedicById(mUser.id);

                        if (mUser.roleId == 2)
                        {


                            response = Request.CreateResponse(HttpStatusCode.OK, new
                            {
                                id = mUser.id,
                                role = mUser.roleId,
                                docNumber = mUser.documentNumber,
                                name = $"{mUser.firstName} {mUser.lastNameFather} {mUser.lastNameMother}",
                                permissions = permissions,
                                IsApproved = medic.IsApproved,
                                IsFreezed = medic.IsFreezed,
                                cmp = medic.cmp,
                                rne = medic.rne
                            });
                        }
                        else
                        {
                            response = Request.CreateResponse(HttpStatusCode.OK, new
                            {
                                id = mUser.id,
                                role = mUser.roleId,
                                docNumber = mUser.documentNumber,
                                name = $"{mUser.firstName} {mUser.lastNameFather} {mUser.lastNameMother}",
                                permissions = permissions
                            });
                        }
                    }
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Forbidden, "Invalid username or password!");
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("~/reauthenticate")]
        public HttpResponseMessage credentials()
        {


            return Request.CreateResponse(HttpStatusCode.OK);

            //Domain.User mUser = new Domain.User();
            //HttpResponseMessage response = null;
            //try
            //{
            //    mUser = userService.Credentials(Request.us);
            //    if (mUser != null)
            //    {
            //        response = Request.CreateResponse(HttpStatusCode.OK, mUser);
            //    }
            //    else
            //    {
            //        response = Request.CreateResponse(HttpStatusCode.Forbidden, "Session Expired!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
            //return response;
        }

        [HttpPost]
        [Route("~/logout")]
        public HttpResponseMessage logout()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "logout");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("confirm-email")]
        public HttpResponseMessage ConfirmEmail(string id, string code)
        {
            try
            {
                var user = userService.ConfirmEmail(id, code);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("forgot-password")]
        public HttpResponseMessage ForgotPassword(string email)
        {
            try
            {
                var user = userService.GetUserByEmail(email);

                if (user != null)
                {
                    var passwordResetLink = Infrastructure.SecurityHelper.GetPasswordResetLink(user, Request);
                    var emailBody = emailService.GetEmailBody(EmailPurpose.ForgotPassword, passwordResetLink);
                    emailService.SendEmailAsync(user.email, "Confirm Email - MedAPI", emailBody, passwordResetLink);


                    //if user valid - generate and send a link
                    return Request.CreateResponse(HttpStatusCode.OK, "Email Sent Success!");
                }

                //else user not valid
                return Request.CreateResponse(HttpStatusCode.NotFound, "User Not Found!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("send-confirmation-again")]
        public HttpResponseMessage SendConfirmationEmailAgain(string email)
        {
            try
            {
                var user = userService.GetUserByEmail(email);

                if (user != null)
                {
                    var emailConfirmationLink = Infrastructure.SecurityHelper.GetEmailConfirmatioLink(user, Request);
                    var emailBody = emailService.GetEmailBody(EmailPurpose.EmailVerification, emailConfirmationLink);
                    emailService.SendEmailAsync(user.email, "Verifique su Email - SolidarityMedical", emailBody, emailConfirmationLink);


                    //if user valid - generate and send a link
                    return Request.CreateResponse(HttpStatusCode.OK, "Email Sent Success!");
                }

                //else user not valid
                return Request.CreateResponse(HttpStatusCode.NotFound, "User Not Found!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("send-test-email")]
        public HttpResponseMessage SendTestEmail(string from, string to)
        {
            try
            {


                var emailBody = "test email";

                var key = ConfigurationManager.AppSettings.Get("EmailApiKey");
                var user = ConfigurationManager.AppSettings.Get("EmailUser");
                var client = new SendGridClient(key);
                var msg = new SendGridMessage
                {
                    From = new EmailAddress(from, user),
                    Subject = "Test",
                    PlainTextContent = emailBody,
                    HtmlContent = emailBody
                };
                msg.AddTo(new EmailAddress(to));
                msg.SetClickTracking(false, false);


                var result = Task.Run(() => client.SendEmailAsync(msg)).GetAwaiter().GetResult();





                //if user valid - generate and send a link
                return Request.CreateResponse(HttpStatusCode.OK, "Email Sent Success!");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("reset-password")]
        public HttpResponseMessage ResetPassowrd(UserWithIdPw user)
        {
            string password = Infrastructure.HashPasswordHelper.HashPassword(user.passwordHash);

            try
            {
                var existingUser = userService.GetUserById(user.id);



                if (existingUser != null)
                {
                    this.userService.ResetPassword(user.id.ToString(), user.token, password);
                    return Request.CreateResponse(HttpStatusCode.OK, "Password Reset Success!");
                }
                else
                {

                    //else user not valid
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User Not Found!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
