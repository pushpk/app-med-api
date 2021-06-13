
using Services.IServices; using Microsoft.AspNetCore.Mvc;
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
using API.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Repository.DTOs;
using Services.Helpers;
using static Services.Helpers.EmailHelper;

namespace API.Controllers
{
    [Route("api/users")]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IEmailService emailService;
        private readonly IMedicService medicService;
        private readonly ILabService labService;
        private readonly IPatientService patientService;

        public UserController(IUserService userService, IEmailService emailService, IMedicService medicService, ILabService labService, IPatientService patientService)
        {
            this.userService = userService;
            this.emailService = emailService;
            this.medicService = medicService;
            this.labService = labService;
            this.patientService = patientService;
        }

        [HttpGet]
        [Authorize]
        [Route("users")]
        public ActionResult List()
        {
            
            try
            {
               return Ok(userService.GetAllUser());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }


        [HttpGet]
        [Authorize]
        [Route("not-approved-medics")]
        public ActionResult GetAllNonApprovedMedics()
        {
            
            try
            {
               return Ok(userService.GetAllNonApprovedMedics());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpGet]
        [Authorize]
        [Route("not-approved-labs")]
        public ActionResult GetAllNonApprovedLabs()
        {
            
            try
            {
               return Ok(userService.GetAllNonApprovedLabs());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpGet]
        [Route("active-user-counts")]
        public ActionResult GetAllUserCounts()
        {
            
            try
            {
                var numPatients = patientService.GetActivePatientCount();
                var numMedics = medicService.GetActiveMedicCount();
                var numLabs = labService.GetActiveLabCount();
               return Ok(new { numPatients, numMedics, numLabs });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           

        }

        [HttpGet]
        [Authorize]
        [Route("users/{id:int}")]
        public ActionResult Show(long id)
        {
            
            try
            {
                User mUser = userService.GetUserById(id);
                if (mUser == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mUser);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("users/{id:int}")]
        public ActionResult Delete(long id)
        {
            
            try
            {
                bool isSuccess = false;
                isSuccess = userService.DeleteUserById(id);
                if (isSuccess)
                {
                   return Ok("Entity removed successfully.");
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           

        }


        [HttpPost]
        [Route("create")]
        public ActionResult Create(User mUser, string currentUrl)
        {
            
            try
            {
                mUser = userService.SaveUser(mUser);

                var emailVerificationLink = SecurityHelper.GetEmailConfirmatioLink(mUser, Request);
                var emailBody = emailService.GetEmailBody(EmailPurpose.EmailVerification, emailVerificationLink);
                emailService.SendEmailAsync(mUser.Email, "Confirm Email - MedAPI", emailBody, emailVerificationLink);

               return Ok(mUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }



        [HttpPost]
        [Authorize]
        [Route("users/{id:int}")]
        public ActionResult Update(User mUser, long id)
        {
            
            try
            {
                mUser.Id = id;
                mUser = userService.SaveUser(mUser);
               return Ok(mUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpGet]
        [Route("resources")]
        public ActionResult Resources()
        {
            
            UserResources mUserResources = new UserResources();
            try
            {
                mUserResources = userService.GetResources();
               return Ok(mUserResources);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }



        [HttpGet]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("Get-User-Info")]
        public ActionResult authenticate()
        {

            return Ok();
            //try
            //{
            //    ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            //    var mUser = userService.GetCurrentUser(principal); 
               
            //    if (mUser != null)
            //    {
            //        if (!mUser.emailConfirmed)
            //        {
            //            return Ok(new { message = "Email_Not_Confirmed" });
            //        }

            //        IEnumerable<string> permissions;
            //        using (var ctx = new DataAccess.registroclinicoEntities())
            //        {
            //            permissions = ctx.role_permissions.Where(s => s.Role_id == mUser.roleId).Select(s => s.permissions).ToArray();

            //            if (mUser.roleId == 2)
            //            {
            //                var medic = this.medicService.GetMedicById(mUser.id);

            //               return Ok(new
            //                {
            //                    id = mUser.id,
            //                    role = mUser.roleId,
            //                    docNumber = mUser.documentNumber,
            //                    name = $"{mUser.firstName} {mUser.lastNameFather} {mUser.lastNameMother}",
            //                    permissions = permissions,
            //                    IsApproved = medic.IsApproved,
            //                    IsFreezed = medic.IsFreezed,
            //                    cmp = medic.cmp,
            //                    rne = medic.rne
            //                });
            //            }
            //            else if (mUser.roleId == 5)
            //            {
            //                var labUser = this.labService.GetLab(mUser.id);

            //               return Ok(new
            //                {
            //                    id = mUser.id,
            //                    role = mUser.roleId,
            //                    docNumber = mUser.documentNumber,
            //                    name = $"{mUser.firstName} {mUser.lastNameFather} {mUser.lastNameMother}",
            //                    permissions = permissions,
            //                    IsApproved = labUser.IsApproved,
            //                    IsFreezed = labUser.IsFreezed

            //                });
            //            }
            //            else
            //            {
            //               return Ok(new
            //                {
            //                    id = mUser.id,
            //                    role = mUser.roleId,
            //                    docNumber = mUser.documentNumber,
            //                    name = $"{mUser.firstName} {mUser.lastNameFather} {mUser.lastNameMother}",
            //                    permissions = permissions
            //                });
            //            }
            //        }
            //    }
            //    else
            //    {
            //        response = Request.CreateResponse(HttpStatusCode.Forbidden, "Invalid username or password!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message.ToString());
                
            //}

           
        }


        [HttpGet]
        [Route("confirm-email")]
        public ActionResult ConfirmEmail(string id, string code)
        {
            try
            {
                var user = userService.ConfirmEmail(id, code);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("forgot-password")]
        public ActionResult ForgotPassword(string email)
        {
            try
            {
                var user = userService.GetUserByEmail(email);

                if (user != null)
                {
                    var passwordResetLink = SecurityHelper.GetPasswordResetLink(user, Request);
                    var emailBody = emailService.GetEmailBody(EmailPurpose.ForgotPassword, passwordResetLink);
                    emailService.SendEmailAsync(user.Email, "Confirm Email - MedAPI", emailBody, passwordResetLink);


                    //if user valid - generate and send a link
                    return Ok("Email Sent Success!");
                }

                //else user not valid
                return NotFound("User Not Found!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("send-confirmation-again")]
        public ActionResult SendConfirmationEmailAgain(string email)
        {
            try
            {
                var user = userService.GetUserByEmail(email);

                if (user != null)
                {
                    var emailConfirmationLink = SecurityHelper.GetEmailConfirmatioLink(user, Request);
                    var emailBody = emailService.GetEmailBody(EmailPurpose.EmailVerification, emailConfirmationLink);
                    emailService.SendEmailAsync(user.Email, "Verifique su Email - SolidarityMedical", emailBody, emailConfirmationLink);


                    //if user valid - generate and send a link
                    return Ok("Email Sent Success!");
                }

                //else user not valid
                return NotFound("User Not Found!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("send-test-email")]
        public ActionResult SendTestEmail(string from, string to)
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
                return Ok("Email Sent Success!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Route("reset-password")]
        public ActionResult ResetPassowrd(UserWithIdPw user)
        {
            string password = HashPasswordHelper.HashPassword(user.passwordHash);

            try
            {
                var existingUser = userService.GetUserById(user.id);



                if (existingUser != null)
                {
                    this.userService.ResetPassword(user.id.ToString(), user.token, password);
                    return Ok("Password Reset Success!");
                }
                else
                {

                    //else user not valid
                    return NotFound("User Not Found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("change-password")]
        public ActionResult ChangePassowrd(UserWithIdPw user)
        {

            string newPassword = HashPasswordHelper.HashPassword(user.passwordHash);
            try
            {
                var existingUser = userService.GetUserById(user.id);



                if (existingUser != null)
                {
                    this.userService.ResetPassword(user.id.ToString(), null, newPassword, false, user.oldPasswordHash);
                    return Ok("Password Change Success!");
                }
                else
                {

                    //else user not valid
                    return NotFound("User Not Found!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet]
        [Route("hash-password")]
        public string HashString(string pw)
        {
            return HashPasswordHelper.HashPassword(pw);

        }

    }
}
