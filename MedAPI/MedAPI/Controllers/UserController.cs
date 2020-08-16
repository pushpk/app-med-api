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

        public UserController(IUserService userService)
        {
            this.userService = userService;
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
        [Route("users")]
        public HttpResponseMessage Create(Domain.User mUser)
        {
            HttpResponseMessage response = null;
            try
            {
                mUser = userService.SaveUser(mUser);
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
        [Route("~/login")]
        public HttpResponseMessage authenticate(Domain.Login mLogin)
        {
            Domain.User mUser = new Domain.User();


            HttpResponseMessage response = null;
            try
            {
                mUser = userService.Authenticate(mLogin.username, mLogin.Password);
                if (mUser != null)
                {
                    IEnumerable<string> permissions;
                    using (var ctx = new DataAccess.registroclinicoEntities())
                    {
                        permissions = ctx.role_permissions.Where(s => s.Role_id == mUser.roleId).Select(s => s.permissions).ToArray();
                    }

                    response = Request.CreateResponse(HttpStatusCode.OK, new { id = mUser.id, name = $"{mUser.firstName} {mUser.lastNameFather} {mUser.lastNameMother}", permissions = permissions });
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
