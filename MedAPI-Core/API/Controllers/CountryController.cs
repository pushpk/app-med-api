using API.Controllers; using API.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
 
using System.Net.Http;
using System.Web;


namespace API.Controllers
{
   // [System.Web.Http.RoutePrefix("api/util")]
   [Route("api/util")]
    public class CountryController : BaseController
    {
        private readonly ICountryService countryService;
        private readonly IUserService userService;
        public CountryController(ICountryService countryService, IUserService userService)
        {
            this.countryService = countryService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("country/{query}")]
       public ActionResult Search(string query)
        {
           
            try
            {
                return Ok(countryService.GetByName(query));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpGet]
        [Route("country")]
       public ActionResult GetAll()
        {
           
            try
            {
                return Ok(countryService.GetAllCountry());
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }
        [HttpGet]
        [Route("country/{id:int}")]
       public ActionResult Show(long id)
        {
           
            try
            {
                Country mCountry = countryService.GetCountryById(id);
                if (mCountry == null)
                {
                  return NotFound("Requested entity was not found in database.");
                }
                else
                {
                    return Ok(mCountry);
                }
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
        }

        [HttpDelete]
        [Route("country/{id:int}")]
       public ActionResult Delete(long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    bool isSuccess = false;
                    isSuccess = countryService.DeleteCountryById(id);
                    if (isSuccess)
                    {
                        return Ok("Entity removed successfully.");

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
        [Route("country")]
       public ActionResult Create(Country mCountry)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mCountry = countryService.SaveCountry(mCountry);
                    return Ok(mCountry);
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
        [Route("country/{id:int}")]
       public ActionResult Update(Country mCountry,long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mCountry.id = id;
                    mCountry = countryService.SaveCountry(mCountry);
                    return Ok(mCountry);
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


        private bool IsAdminPermission()
        {
            bool result = false;
            var email = Request.Headers["email"].ToString();
            var user = userService.GetByEmail(email);
            if (user != null)
            {
                if (user.roleId == (int)Infrastructure.Common.Permission.ADMIN)
                {
                    result= true;
                }
            }
            return result;
        }
    }
}
