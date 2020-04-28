using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("util")]
    public class EstablishmentController : ApiController
    {
        private readonly IEstablishmentService establishmentService;
        private readonly IUserService userService;
        public EstablishmentController(IEstablishmentService establishmentService, IUserService userService)
        {
            this.establishmentService = establishmentService;
            this.userService = userService;
        }
        [HttpGet]
        [Route("establishment")]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, establishmentService.GetAllEstablishment());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("establishment")]
        public HttpResponseMessage Create(Domain.Establishment mEstablishment)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mEstablishment = establishmentService.SaveEstablishment(mEstablishment);
                    response = Request.CreateResponse(HttpStatusCode.OK, mEstablishment);
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
        [Route("establishment/{id:int}")]
        public HttpResponseMessage Update(Domain.Establishment mEstablishment,long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mEstablishment.Id = id;
                    mEstablishment = establishmentService.SaveEstablishment(mEstablishment);
                    response = Request.CreateResponse(HttpStatusCode.OK, mEstablishment);
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
        [HttpGet]
        [Route("establishment/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Domain.Establishment mEstablishment = establishmentService.GetEstablishmentById(id);
                if (mEstablishment == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mEstablishment);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpDelete]
        [Route("establishment/{id:int}")]
        public HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    bool isSuccess = false;
                    isSuccess = establishmentService.DeleteEstablishmentById(id);
                    if (isSuccess)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, "Entity removed successfully.");
                    }
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
                if (user.RoleId == (int)Infrastructure.Common.Permission.ADMIN)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
