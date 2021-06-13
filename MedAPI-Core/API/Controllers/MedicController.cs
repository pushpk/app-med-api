using Repository.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using API.Controllers;   using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static Services.Helpers.EmailHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Data.DataModels;
using AutoMapper;
using Infrastructure;

namespace API.Controllers
{

    [Route("api/users")]
    [Authorize]
    public class MedicController : BaseController
    {
        private readonly IMedicService medicService;
        private readonly IUserService userService;
        private readonly IEmailService emailService;
        private readonly UserManager<user> _userManager;
        private readonly IMapper _mapper;


        public MedicController(IMedicService medicService, IUserService userService, IEmailService emailService, UserManager<user> userManager, IMapper mapper)
        {
            this.medicService = medicService;
            this.userService = userService;
            this.emailService = emailService;
            _userManager = userManager;
            this._mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("medic")]
        public ActionResult GetAll()
        {
           
            try
            {
               return Ok(medicService.GetAllMedic());
                //if(IsAdminPermission())
                //  return Ok(medicService.GetAllMedic());
                //else
                //   return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Route("medic/{id:int}")]
        public ActionResult Show(long id)
        {
           
            try
            {
                Medic mMedic = medicService.GetMedicById(id);
                if (mMedic == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mMedic);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Route("get-medic")]
        public ActionResult GetMedicId(long id)
        {
           
            try
            {
                Medic mMedic = medicService.GetMedicById(id);
                if (mMedic == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mMedic);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("freeze-medic")]
        public ActionResult FreezeMedic(long id)
        {
           
            try
            {
                Medic mMedic = medicService.GetMedicById(id);

                mMedic.IsFreezed = !mMedic.IsFreezed;
                mMedic = medicService.UpdateMedic(mMedic);

                if (mMedic == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mMedic);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("approve-medic")]
        public ActionResult AprroveMedic(long id)
        {
           
            try
            {
                Medic mMedic = medicService.GetMedicById(id);

                mMedic.IsApproved = true;
                mMedic.IsDenied = false;
                mMedic = medicService.UpdateMedic(mMedic);
                var emailBody = emailService.GetEmailBody(EmailPurpose.ApproveAccount);
                //emailService.SendEmailAsync(mMedic.user.email, "Medic Approved -  MedAPI", emailBody);
                emailService.SendEmailAsync(mMedic.user.email, "Cuenta Aprobada - SolidarityMedical", emailBody);

                if (mMedic == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mMedic);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("deny-medic")]
        public ActionResult DenyMedic(long id)
        {
           
            try
            {
                Medic mMedic = medicService.GetMedicById(id);

                mMedic.IsDenied = true;
                mMedic.IsApproved = false;
                mMedic = medicService.UpdateMedic(mMedic);
                var emailBody = emailService.GetEmailBody(EmailPurpose.DenyAccount);
                emailService.SendEmailAsync(mMedic.user.email, "Cuenta Denegada - SolidarityMedical", emailBody);

                if (mMedic == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mMedic);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("medic/{id:int}")]
        public ActionResult Delete(long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    bool isSuccess = false;
                    isSuccess = medicService.DeleteMedicById(id);
                    if (isSuccess)
                    {
                       return Ok("Entity removed successfully.");
                    }
                    else
                       return Ok("Invalid Entity. Not found");
                }
                else
                {
                    return Unauthorized();
                    
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("medic")]
        public ActionResult Create(Medic mMedic)
        {
           

            if (userService.IsUserAlreadyExist(mMedic.user, mMedic.cmp))
            {
                return BadRequest("User Already Exist");
                
            }
            else
            {
                try
                {

                    mMedic = medicService.SaveMedic(mMedic);

                    var emailConfirmationLink = SecurityHelper.GetEmailConfirmatioLink(mMedic.user, Request, _userManager, _mapper);
                    var emailBody = emailService.GetEmailBody(EmailPurpose.EmailVerification, emailConfirmationLink.ToString());
                    emailService.SendEmailAsync(mMedic.user.email, "Verificacion de Email - SolidarityMedical", emailBody, emailConfirmationLink.ToString());


                   return Ok(mMedic);


                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
          
        }

       

        [HttpPost]
        [Route("medic/{id:int}")]
        public ActionResult Update(Medic mMedic, long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mMedic.user.id = id;
                    mMedic = medicService.SaveMedic(mMedic);
                   return Ok(mMedic);
                }
                else
                {
                    return Unauthorized();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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
                    result = true;
                }
            }
            return result;
        }
    }
}
