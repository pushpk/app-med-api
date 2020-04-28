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
    [System.Web.Http.RoutePrefix("util")]
    public class ProvinceController : ApiController
    {
        private readonly IProvinceService provinceService;
        private readonly IUserService userService;
        public ProvinceController(IProvinceService provinceService, IUserService userService)
        {
            this.provinceService = provinceService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("province/{query?}/{department:int?}")]
        public HttpResponseMessage Search(string query=null,int department=0)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, provinceService.Search(query, department));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("province")]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, provinceService.GetAllProvince());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("province")]
        public HttpResponseMessage Create(Domain.Province mProvince)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mProvince = provinceService.SaveProvince(mProvince);
                    response = Request.CreateResponse(HttpStatusCode.OK, mProvince);
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
        [Route("province/{id:int}")]
        public HttpResponseMessage Update(Domain.Province mProvince,long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mProvince.Id = id;
                    mProvince = provinceService.SaveProvince(mProvince);
                    response = Request.CreateResponse(HttpStatusCode.OK, mProvince);
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

        [HttpGet]
        [Route("province/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Domain.Province mProvince = provinceService.GetProvinceById(id);
                if (mProvince == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mProvince);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpDelete]
        [Route("province/{id:int}")]
        public HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    bool isSuccess = false;
                    isSuccess = provinceService.DeleteProvinceById(id);
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
