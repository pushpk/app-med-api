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
    [System.Web.Http.RoutePrefix("api/users")]
    public class NurseController : ApiController
    {
        private readonly INurseService nurseService;
        private readonly IUserService userService;
        public NurseController(INurseService nurseService, IUserService userService)
        {
            this.nurseService = nurseService;
            this.userService = userService;
        }
        [HttpGet]
        [Route("nurse")]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, nurseService.GetAll());
                //if (IsAdminPermission())
                //{
                //    response = Request.CreateResponse(HttpStatusCode.OK, nurseService.GetAll());
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

        [HttpGet]
        [Route("nurse/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Nurse mNurse = nurseService.GetNurseById(id);
                if (mNurse == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mNurse);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }



        [HttpPost]
        [Route("nurse")]
        public HttpResponseMessage Create(Domain.Nurse mNurse)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mNurse = nurseService.SaveNurse(mNurse);
                    response = Request.CreateResponse(HttpStatusCode.OK, mNurse);
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
        [Route("nurse/{id:int}")]
        public HttpResponseMessage Update(Domain.Nurse mNurse,long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mNurse.user.id = id;
                    mNurse = nurseService.SaveNurse(mNurse);
                    response = Request.CreateResponse(HttpStatusCode.OK, mNurse);
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
