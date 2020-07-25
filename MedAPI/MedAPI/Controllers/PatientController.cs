using MedAPI.ExceptionFormatter;
using MedAPI.Infrastructure.IService;
using MedAPI.models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("users")]
    public class PatientController : ApiController
    {
        private readonly IUserService userService;
        private readonly IPatientService patientService;
        private readonly INoteService noteService;


        public PatientController(IUserService userService, IPatientService patientService, INoteService noteService)
        {
            this.userService = userService;
            this.patientService = patientService;
            this.noteService = noteService;
        }
        [HttpGet]
        [Route("patient")]
        public HttpResponseMessage GetAll()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, patientService.GetAllPatient());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("patient/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Domain.Patient mPatient = patientService.GetPatientById(id);
                if (mPatient == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mPatient);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpPost]
        [Route("patient")]
        public HttpResponseMessage Create(Patient mPatient)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    var patient = setPatientInfo(mPatient);
                    var responsePatient = patientService.SavePatient(patient);
                    response = Request.CreateResponse(HttpStatusCode.OK, responsePatient);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, newException);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpPost]
        [Route("patient/{id:int}")]
        public HttpResponseMessage Create(Patient mPatient, long id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsAdminPermission())
                {
                    mPatient.id = id;
                    var patient = setPatientInfo(mPatient);
                    var responsePatient = patientService.SavePatient(patient);
                    response = Request.CreateResponse(HttpStatusCode.OK, responsePatient);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, newException);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpDelete]
        [Route("patient/{id:int}")]
        public HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                bool isSuccess = false;
                isSuccess = patientService.DeletePatientById(id);
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

        [HttpGet]
        [Route("~/department/{id:int}/provinces")]
        public HttpResponseMessage GetProvinceByDepartment(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, patientService.GetProvinceByDepartment(id));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }
        [HttpGet]
        [Route("~/province/{id:int}/districts")]
        public HttpResponseMessage GetDistrictByprovinceId(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, patientService.GetDistrictByprovinceId(id));
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("~/record/patient")]
        public HttpResponseMessage GetPatient(int documentNumber)
        {
            //Domain.User pat = patientService.GetPatientByDocumentNumber(documentNumber);
            Domain.Patient pat = patientService.GetPatientByDocumentNumber(documentNumber);

            var notes = noteService.GetAllNoteByPatient(Convert.ToInt32(pat.id));

            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new { patient = pat, notes = notes });
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
                    result = true;
                }
            }
            return result;
        }

        public Domain.Patient setPatientInfo(Patient mPatient)
        {
            Domain.Patient patient = new Domain.Patient();
            patient.id = mPatient.id;
            patient.alcohol = mPatient.alcoholConsumption;
            patient.bloodType = mPatient.bloodType;
            patient.cigaretteNumber = mPatient.cigaretteNumber;
            patient.createdTicket = string.Empty;
            patient.dormNumber = mPatient.dormNumber;
            patient.educationalAttainment = mPatient.educationalAttainment;
            patient.electricity = mPatient.home.electricity;
            patient.fractureNumber = mPatient.fractureNumber;
            patient.fruitsVegetables = mPatient.fvConsumption;
            patient.highGlucose = mPatient.highGlucose;
            patient.homeMaterial = mPatient.home.material;
            patient.homeOwnership = mPatient.home.ownership;
            patient.homeType = mPatient.home.type;
            patient.occupation = mPatient.occupation;
            patient.otherAllergies = mPatient.otherAllergies;
            patient.otherFatherBackground = mPatient.otherFatherBackground;
            patient.otherMedicines = mPatient.otherMedicines;
            patient.otherMotherBackground = mPatient.otherMotherBackground;
            patient.otherPersonalBackground = mPatient.otherPersonalBackground;
            patient.physicalActivity = mPatient.physicalActivity;
            patient.residentNumber = 0;
            patient.water = mPatient.home.water;
            patient.sewage = mPatient.home.sewage;
            patient.user = setUserInfo(mPatient);
            return patient;
        }

        public Domain.User setUserInfo(Patient mPatient)
        {
            var userData = getUserInfo();
            Domain.User user = new Domain.User();
            user.id = mPatient.userId;
            user.address = mPatient.address;
            user.birthday = mPatient.birthday;
            user.cellphone = mPatient.phone;
            if (userData != null)
            {
                user.createdBy = Convert.ToString(userData.id);
            }
            user.createdDate = DateTime.Now;
            user.documentNumber = mPatient.documentNumber;
            user.documentType = mPatient.documentType;
            user.email = mPatient.email;
            user.firstName = mPatient.name;
            user.lastNameFather = mPatient.lastnameFather;
            user.lastNameMother = mPatient.lastnameMother;
            user.maritalStatus = mPatient.maritalStatus;
            user.organDonor = mPatient.isDonor;
            if (mPatient.userId > 0)
            {
                user.modifiedBy = Convert.ToString(userData.id);
                user.modifiedDate = DateTime.Now;
            }
            user.passwordHash = mPatient.passwordHash;
            user.sex = mPatient.sex;
            user.since = DateTime.Now;

            user.countryId = mPatient.country;
            user.districtId = mPatient.district;

            if (userData != null)
            {
                user.roleId = userData.roleId;
                user.role = userData.role;
            }
            return user;
        }
        public Domain.User getUserInfo()
        {
            var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            string email = Convert.ToString(headerValues.FirstOrDefault());
            return userService.GetByEmail(email);
        }
    }
}
