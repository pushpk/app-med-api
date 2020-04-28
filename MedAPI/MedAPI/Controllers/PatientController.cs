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
    public class PatientController : ApiController
    {
        private readonly IUserService userService;
        private readonly IPatientService patientService;
        
        public PatientController(IUserService userService, IPatientService patientService)
        {
            this.userService = userService;
            this.patientService = patientService;
        }
        [HttpGet]
        [Route("patient")]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                    response = Request.CreateResponse(HttpStatusCode.OK, patientService.GetAllPatient());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("patient/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Patient mPatient = patientService.GetPatientById(id);
                if (mPatient == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mPatient);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpPost]
        [Route("patient")]
        public HttpResponseMessage Create(Domain.Patient mPatient)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mPatient = patientService.SavePatient(mPatient);
                    response = Request.CreateResponse(HttpStatusCode.OK, mPatient);
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
        [Route("patient/{id:int}")]
        public HttpResponseMessage Create(Domain.Patient mPatient,long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mPatient.User.Id = id;
                    mPatient = patientService.SavePatient(mPatient);
                    response = Request.CreateResponse(HttpStatusCode.OK, mPatient);
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


        [HttpDelete]
        [Route("patient/{id:int}")]
        public HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                    bool isSuccess = false;
                    isSuccess = patientService.DeletePatientById(id);
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

        [HttpGet]
        [Route("department/{id:int}/provinces")]
        public HttpResponseMessage GetProvinceByDepartment(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                   response = Request.CreateResponse(HttpStatusCode.OK, patientService.GetProvinceByDepartment(id));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("province/{id:int}/districts")]
        public HttpResponseMessage GetDistrictByprovinceId(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, patientService.GetDistrictByprovinceId(id));
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
