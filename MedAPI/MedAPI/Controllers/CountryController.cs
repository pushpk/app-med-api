using MedAPI.Domain;
using MedAPI.Extention;
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
    [System.Web.Http.RoutePrefix("api/util")]
    public class CountryController : ApiController
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
        public HttpResponseMessage Search(string query)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK,countryService.GetByName(query));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("country")]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, countryService.GetAllCountry());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("country/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Country mCountry = countryService.GetCountryById(id);
                if (mCountry == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mCountry);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpDelete]
        [Route("country/{id:int}")]
        public HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    bool isSuccess = false;
                    isSuccess = countryService.DeleteCountryById(id);
                    if (isSuccess)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, "Entity removed successfully.");
                    }
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
        [Route("country")]
        public HttpResponseMessage Create(Domain.Country mCountry)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mCountry = countryService.SaveCountry(mCountry);
                    response = Request.CreateResponse(HttpStatusCode.OK, mCountry);
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
        [Route("country/{id:int}")]
        public HttpResponseMessage Update(Domain.Country mCountry,long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mCountry.id = id;
                    mCountry = countryService.SaveCountry(mCountry);
                    response = Request.CreateResponse(HttpStatusCode.OK, mCountry);
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
                    result= true;
                }
            }
            return result;
        }
    }
}
