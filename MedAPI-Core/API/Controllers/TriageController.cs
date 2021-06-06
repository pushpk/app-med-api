using Services.IServices; using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using API.Controllers;
using Repository.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/Triage")]
    [Authorize]
    public class TriageController : BaseController
    {
        private readonly ITriageService triageService;
        public TriageController(ITriageService triageService)
        {
            this.triageService = triageService;
        }
        [HttpPost]
        [Route("GetLatest")]
        public ActionResult GetLatest(Patient mPatient)
        {
            
            try
            {
                Triage mTriage = triageService.GetLatest(mPatient);
                if (mTriage == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mTriage);
                }
            }
            catch (Exception ex)
            {
                return NotFound("Requested entity was not found in database.");
                
            }
           
        }
    }
}
