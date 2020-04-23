using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/CardiovascularNote")]
    public class CardiovascularNoteController : ApiController
    {
        private readonly ICardiovascularNoteService cardiovascularNoteService;

        public CardiovascularNoteController(ICardiovascularNoteService cardiovascularNoteService)
        {
            this.cardiovascularNoteService = cardiovascularNoteService;
        }

        [HttpGet]
        [Route("List")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, cardiovascularNoteService.GetAllCardiovascularNote());
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
                CardiovascularNote mCardiovascularNote = cardiovascularNoteService.GetCardiovascularNoteById(id);
                if (mCardiovascularNote == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mCardiovascularNote);
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
                isSuccess = cardiovascularNoteService.DeleteCardiovascularNoteById(id);
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
        [Route("Create")]
        public HttpResponseMessage Create(CardiovascularNote mCardiovascularNote)
        {
            HttpResponseMessage response = null;
            try
            {
                if (mCardiovascularNote != null)
                {
                    int id = cardiovascularNoteService.SaveCardiovascularNote(mCardiovascularNote);

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
        public HttpResponseMessage Update(CardiovascularNote mCardiovascularNote)
        {
            HttpResponseMessage response = null;
            try
            {
                if (mCardiovascularNote != null)
                {
                    int id = cardiovascularNoteService.SaveCardiovascularNote(mCardiovascularNote);

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

    }
}
