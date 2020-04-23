using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/Patient")]
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
        [Route("List")]
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
        [Route("Show/{id:int}")]
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

        [HttpGet]
        [Route("Delete/{id:int}")]
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
        [Route("GetProvinceByDepartment/{id:int}")]
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
        [Route("GetDistrictByprovinceId/{id:int}")]
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
        //[HttpGet]
        //[Route("GetPatientByDocumentNumber/{documentNumber}")]
        //public HttpResponseMessage GetPatientByDocumentNumber(string documentNumber)
        //{
        //    HttpResponseMessage response = null;
        //    try
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.OK, patientService.GetPatientByDocumentNumber(documentNumber));
        //    }
        //    catch (Exception ex)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //    return response;
        //}
    }
}
