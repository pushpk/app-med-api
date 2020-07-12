using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("admin")]
    public class DiagnosisController : ApiController
    {
        private readonly IDiagnosisService diagnosisService;
        private readonly IUserService userService;

        public DiagnosisController(IDiagnosisService diagnosisService,IUserService userService)
        {
            this.diagnosisService = diagnosisService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("diagnosis/{query?}")]
        public HttpResponseMessage Search(string query="")
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
        [Route("diagnosis")]
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
        [Route("diagnosis/{id:int}")]
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
        [Route("diagnosis")]
        public HttpResponseMessage Create(Diagnosis mDiagnosis)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
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
                    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("diagnosis/{id:int}")]
        public HttpResponseMessage Update(Diagnosis mDiagnosis,long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mDiagnosis.Id = id;
                     id = diagnosisService.SaveDiagnosis(mDiagnosis);

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
                    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpDelete]
        [Route("diagnosis/{id:int}")]
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


