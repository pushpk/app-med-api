using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("users")]
    public class UserController : ApiController
    {
        private readonly IUserService userService;
        private readonly IEmailService emailService;

        public UserController(IUserService userService, IEmailService emailService)
        {
            this.userService = userService;
            this.emailService = emailService;
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
                var emailConfirmationLink = GenerateLink(mUser);
                //emailService.SendEmailAsync()
                response = Request.CreateResponse(HttpStatusCode.OK, mUser);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [NonAction]
        private string GenerateLink(User mUser)
        {
            throw new NotImplementedException();
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
                    if(!mUser.emailConfirmed)
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized, "El correo electrónico aún no está confirmado, haga clic en el enlace de activación del correo electrónico para confirmar el correo electrónico.");
                    }

                    
                    IEnumerable<string> permissions;
                    using (var ctx = new DataAccess.registroclinicoEntities())
                    {
                        permissions = ctx.role_permissions.Where(s => s.Role_id == mUser.roleId).Select(s => s.permissions).ToArray();

                        var medic = ctx.medics.FirstOrDefault(s => s.id == mUser.id);

                        if (mUser.roleId == 2)
                        {
                            response = Request.CreateResponse(HttpStatusCode.OK, new { id = mUser.id,
                                role = mUser.roleId,
                                docNumber = mUser.documentNumber,
                                name = $"{mUser.firstName} {mUser.lastNameFather} {mUser.lastNameMother}",
                                permissions = permissions,
                                IsApproved = medic.IsApproved,
                                IsFreezed = medic.IsFreezed
                            });
                        }
                        else
                        {
                            response = Request.CreateResponse(HttpStatusCode.OK, new { id = mUser.id, role = mUser.roleId, 
                                docNumber = mUser.documentNumber, name = $"{mUser.firstName} {mUser.lastNameFather} {mUser.lastNameMother}", 
                                permissions = permissions });
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

    }
}
