using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using dPatient = Data.Model.Patient;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;
        private readonly IMapper mapper;

        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            this.patientRepository = patientRepository;
            this.mapper = mapper;
        }


        [HttpPost]
        [Route("patient")]
        public bool Create(Patient patient)
        {
            try
            {
                var patientD = mapper.Map<dPatient>(patient);

                this.patientRepository.SavePatient(patientD);
               
                //if (userService.IsUserAlreadyExist(patient.user) && !mPatient.IsEdit)
                //{
                //    response = Request.CreateResponse(HttpStatusCode.Conflict, "User Already Exist");
                //}
                //else
                //{
                //    Domain.Patient responsePatient = CreatePatient(mPatient);
                //    response = Request.CreateResponse(HttpStatusCode.OK, responsePatient);
                //}

            }
            //catch (DbEntityValidationException e)
            //{
            //    var newException = new FormattedDbEntityValidationException(e);
            //    response = Request.CreateResponse(HttpStatusCode.InternalServerError, newException);
            //}
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return true;
        }
    }
}
