using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("record")]
    public class NoteController : ApiController
    {
        private readonly INoteService noteService;
        private readonly IUserService userService;
        public NoteController(INoteService noteService, IUserService userService)
        {
            this.noteService = noteService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("note")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, noteService.GetAllNote());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("note/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Note mNote = noteService.GetNoteById(id);
                if (mNote == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mNote);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpDelete]
        [Route("note/{id:int}")]
        public HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                bool isSuccess = false;
                isSuccess = noteService.DeleteNoteById(id);
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
        [Route("note")]
        public HttpResponseMessage Create(Domain.Note mNote)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsTRIAGEPermission() || IsAdminPermission())
                {
                    mNote = noteService.SaveNote(mNote);
                    response = Request.CreateResponse(HttpStatusCode.OK, mNote);
                }
                else
                {
                    mNote.Triage = noteService.TriageSave(mNote.Triage);
                    response = Request.CreateResponse(HttpStatusCode.OK, mNote.Triage);
                }

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("note/{id:int}")]
        public HttpResponseMessage Update(Domain.Note mNote,long id)
        {
            HttpResponseMessage response = null;
            try
            {
                mNote.Id = id;
                mNote = noteService.SaveNote(mNote);
                response = Request.CreateResponse(HttpStatusCode.OK, mNote);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("resources/note")]
        public HttpResponseMessage Resources()
        {
            HttpResponseMessage response = null;
            Domain.NoteResources mNoteResources = new NoteResources();
            try
            {
                mNoteResources = noteService.GetResources();
                response = Request.CreateResponse(HttpStatusCode.OK, mNoteResources);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        //[HttpGet]
        //[Route("resources/cardiology")]
        //public HttpResponseMessage ResourcesCardiology()
        //{
        //    HttpResponseMessage response = null;
        //    Domain.NoteResources mNoteResources = new NoteResources();
        //    try
        //    {
        //        mNoteResources = noteService.GetResources();
        //        response = Request.CreateResponse(HttpStatusCode.OK, mNoteResources);
        //    }
        //    catch (Exception ex)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //    return response;
        //}
        public bool IsTRIAGEPermission()
        {
            bool result = false;
            var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            string email = Convert.ToString(headerValues.FirstOrDefault());
            var user = userService.GetByEmail(email);
            if (user != null)
            {
                if (user.roleId == (int)Infrastructure.Common.Permission.TRIAGE)
                {
                    result = true;
                }
            }
            return result;
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
