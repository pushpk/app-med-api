using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/Exam")]
    public class ExamController : ApiController
    {
        private readonly IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpGet]
        [Route("Search/{query}")]
        public HttpResponseMessage Search(string query)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, examService.SearchByName(query));
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
                response = Request.CreateResponse(HttpStatusCode.OK, examService.GetAllExam());
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
                Exam mExam = examService.GetExamById(id);
                if (mExam == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                    response = Request.CreateResponse(HttpStatusCode.OK, mExam);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;

        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(Exam mExam)
        {
            HttpResponseMessage response = null;
            try
            {
                if (mExam != null)
                {
                    int id = examService.SaveExam(mExam);

                    if (id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, id);
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

        [HttpPost]
        [Route("Update")]
        public HttpResponseMessage Update(Exam mExam)
        {
            HttpResponseMessage response = null;
            try
            {
                if (mExam != null)
                {
                    int id = examService.SaveExam(mExam);

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
                isSuccess = examService.DeleteExamById(id);
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
