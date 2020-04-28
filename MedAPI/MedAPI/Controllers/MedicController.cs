using MedAPI.Domain;
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

    [System.Web.Http.RoutePrefix("users")]
    public class MedicController : ApiController
    {
        private readonly IMedicService medicService;
        private readonly IUserService userService;
        public MedicController(IMedicService medicService, IUserService userService)
        {
            this.medicService = medicService;
            this.userService = userService;
        }
        [HttpGet]
        [Route("medic")]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                if(IsAdminPermission())
                   response = Request.CreateResponse(HttpStatusCode.OK, medicService.GetAllMedic());
                else
                    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
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

        [HttpDelete]
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
        [Route("medic")]
        public HttpResponseMessage Create(Domain.Medic mMedic)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
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
        [HttpPost]
        [Route("medic/{id:int}")]
        public HttpResponseMessage Update(Domain.Medic mMedic, long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mMedic.User.Id = id;
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
                if (user.RoleId == (int)Infrastructure.Common.Permission.ADMIN)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
