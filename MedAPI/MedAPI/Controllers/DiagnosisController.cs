using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/Diagnosis")]
    public class DiagnosisController : ApiController
    {
        private readonly IDiagnosisService diagnosisService;

        public DiagnosisController(IDiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
        }

        [HttpGet]
        [Route("Search/{query}")]
        public HttpResponseMessage Search(string query)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, diagnosisService.SearchByCode(query));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("List")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, diagnosisService.GetAllDiagnosis());
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
                Diagnosis mDiagnosis = diagnosisService.GetDiagnosisById(id);
                if (mDiagnosis == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mDiagnosis);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;

        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(Diagnosis mDiagnosis)
        {
            HttpResponseMessage response = null;
            try
            {
                if (mDiagnosis != null)
                {
                    int id = diagnosisService.SaveDiagnosis(mDiagnosis);

                    if (id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, id);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.Forbidden, "");
                    }
                }else
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal server error");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("Update")]
        public HttpResponseMessage Update(Diagnosis mDiagnosis)
        {
            HttpResponseMessage response = null;
            try
            {
                if (mDiagnosis != null)
                {
                    int id = diagnosisService.SaveDiagnosis(mDiagnosis);

                    if (id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, id);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.Forbidden, "");
                    }
                }
                else
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal server error");
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
                isSuccess = diagnosisService.DeleteDiagnosisById(id);
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
    }
}


