
using API.Controllers; 
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs;
using Services.IServices;
using System;
using System.Linq;
 
using System.Net.Http;
using System.Web;


namespace API.Controllers
{
   // [System.Web.Http.RoutePrefix("api/record")]
    public class CardiovascularNoteController : BaseController
    {
        private readonly ICardiovascularNoteService cardiovascularNoteService;
        private readonly IUserService userService;

        public CardiovascularNoteController(ICardiovascularNoteService cardiovascularNoteService, IUserService userService)
        {
            this.cardiovascularNoteService = cardiovascularNoteService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("cardiology")]
       public ActionResult List()
        {
            try
            {
                return Ok(cardiovascularNoteService.GetAllCardiovascularNote());
             
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                
            }
           
        }

        [HttpGet]
        [Route("cardiology/{id:int}")]
       public ActionResult Show(long id)
        {
           
            try
            {
                CardiovascularNote mCardiovascularNote = cardiovascularNoteService.GetCardiovascularNoteById(id);
                if (mCardiovascularNote == null)
                {
                    return NotFound("Requested entity was not found in database.");
                    
                }
                else
                {
                    return Ok(mCardiovascularNote);
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpDelete]
        [Route("cardiology/{id:int}")]
       public ActionResult Delete(long id)
        {
           
            try
            {
                bool isSuccess = false;
                isSuccess = cardiovascularNoteService.DeleteCardiovascularNoteById(id);
                if (isSuccess)
                {
                    return Ok("Entity removed successfully.");
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           

        }

        [HttpPost]
        [Route("cardiology")]
       public ActionResult Create(CardiovascularNote mCardiovascularNote)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                     int id = cardiovascularNoteService.SaveCardiovascularNote(mCardiovascularNote);

                        if (id > 0)
                        {
                            return Ok(id);
                        }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return Unauthorized();
                }

            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpPost]
        [Route("cardiology/{id:int}")]
       public ActionResult Update(CardiovascularNote mCardiovascularNote,long id)
        {
            throw new System.NotImplementedException();
            //try
            //{
            //    if (IsAdminPermission())
            //    {
            //        mCardiovascularNote.id = id;
            //         id = cardiovascularNoteService.SaveCardiovascularNote(mCardiovascularNote);

            //        if (id > 0)
            //        {
            //            return Ok(id);
            //        }
            //    }
            //    else
            //        return Unauthorized();
            //}
            //catch (Exception ex)
            //{
            //     return StatusCode(500, ex.Message.ToString());
            //}

        }

        [HttpGet]
        [Route("resources/cardiology")]
       public ActionResult Resources()
        {
            throw new System.NotImplementedException();

            //Domain.CardiovascularResource mNoteResources = new CardiovascularResource();
            //try
            //{
            //    mNoteResources = cardiovascularNoteService.GetResources();
            //    return Ok(mNoteResources);
            //}
            //catch (Exception ex)
            //{
            //     return StatusCode(500, ex.Message.ToString());
            //}

        }

        private bool IsAdminPermission()
        {
            throw new System.NotImplementedException();

            //bool result = false;
            //var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            //string email = Convert.ToString(headerValues.FirstOrDefault());
            //var user = userService.GetByEmail(email);
            //if (user != null)
            //{
            //    if (user.roleId == (int)Infrastructure.Common.Permission.ADMIN)
            //    {
            //        result = true;
            //    }
            //}
            //return result;
        }
    }
}
