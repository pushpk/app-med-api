using Services.IServices; using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Controllers;

namespace API.Controllers
{
    [Route("api/Permission")]
    public class PermissionController : BaseController
    {
        private readonly IPermissionService permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            
            try
            {
               return Ok(permissionService.GetAllPermission());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
           
        }
    }
}
