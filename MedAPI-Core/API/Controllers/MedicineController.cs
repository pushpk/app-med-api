using Repository.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using API.Controllers;   using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/admin")]
    public class MedicineController : BaseController
    {
        private readonly IMedicineService medicineService;
        private readonly IUserService userService;

        public MedicineController(IMedicineService medicineService, IUserService userService)
        {
            this.medicineService = medicineService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("medicine")]
        public ActionResult Search(string query=null)
        {
           
            try
            {
               return Ok(medicineService.SearchByName(query));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        //[HttpGet]
        //[Route("medicine")]
        //public ActionResult List()
        //{
        //   
        //    try
        //    {
        //       return Ok(medicineService.GetAllMedicine());
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //  
        //}

        [HttpGet]
        [Route("medicine/{id:int}")]
        public ActionResult Show(long id)
        {
           
            try
            {
                Medicine mMedicine = medicineService.GetMedicineById(id);
                if (mMedicine == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                   return Ok(mMedicine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          

        }

        [HttpPost]
        [Route("medicine")]
        public ActionResult Create(Medicine mMedicine)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    int id = medicineService.SaveMedicine(mMedicine);

                    if (id > 0)
                    {
                       return Ok(id);
                    }
                    else
                        return StatusCode(500);
                }
                else
                   return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpPost]
        [Route("medicine/{id:int}")]
        public ActionResult Update(Medicine mMedicine,long id)
        {
           
            try
            {
                if (IsAdminPermission())
                {
                    mMedicine.id = id;
                     id = medicineService.SaveMedicine(mMedicine);

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
                   return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpDelete]
        [Route("medicine/{id:int}")]
        public ActionResult Delete(long id)
        {
           
            try
            {
                bool isSuccess = false;
                if (IsAdminPermission())
                {
                    isSuccess = medicineService.DeleteMedicineById(id);
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
