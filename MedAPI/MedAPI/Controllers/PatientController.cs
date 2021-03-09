using MedAPI.Domain;
using MedAPI.ExceptionFormatter;
using MedAPI.Extention;
using MedAPI.Infrastructure.IService;
using MedAPI.models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using static MedAPI.Infrastructure.EmailHelper;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/users")]
    public class PatientController : ApiController
    {
        private readonly IUserService userService;
        private readonly IPatientService patientService;
        private readonly INoteService noteService;
        private readonly IEmailService emailService;


        public PatientController(IUserService userService, IPatientService patientService, INoteService noteService, IEmailService emailService)
        {
            this.userService = userService;
            this.patientService = patientService;
            this.noteService = noteService;
            this.emailService = emailService;
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
        public HttpResponseMessage Create(models.Patient mPatient)
        {
            HttpResponseMessage response = null;
            try
            {
                
                    var patient = setPatientInfo(mPatient);

                    if (userService.IsUserAlreadyExist(patient.user) && !mPatient.IsEdit)
                    {
                        response = Request.CreateResponse(HttpStatusCode.Conflict, "User Already Exist");
                    }
                    else
                    {
                        Domain.Patient responsePatient = CreatePatient(mPatient);
                        response = Request.CreateResponse(HttpStatusCode.OK, responsePatient);
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
        [Route("RegisterPatient")]
        public HttpResponseMessage RegisterPatient(models.Patient mPatient)
        {
            HttpResponseMessage response = null;
            try
            {
                var patient = setPatientInfo(mPatient);

                if (userService.IsUserAlreadyExist(patient.user))
                {
                    response = Request.CreateResponse(HttpStatusCode.Conflict, "User Already Exist");
                }
                else
                {

                    Domain.Patient responsePatient = CreatePatient(mPatient);

                    var emailConfirmationLink = Infrastructure.SecurityHelper.GetEmailConfirmatioLink(responsePatient.user, Request);
                    var emailBody = emailService.GetEmailBody(EmailPurpose.EmailVerification, emailConfirmationLink);
                    emailService.SendEmailAsync(responsePatient.user.email, "Verifique su Email - SolidarityMedical", emailBody, emailConfirmationLink);

                    response = Request.CreateResponse(HttpStatusCode.OK, responsePatient);
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



        private Domain.Patient CreatePatient(models.Patient mPatient)
        {
            var patient = setPatientInfo(mPatient);
            var responsePatient = patientService.SavePatient(patient);
            mPatient.id = responsePatient.id;
            var patientAllergies = setAllergyList(mPatient);
            patientService.SaveAllergiesList(patientAllergies);

            var patientMedicines = setMedicinesList(mPatient);
            patientService.SaveMedicinesList(patientMedicines);

            var patientPersonalBackgrounds = setPersonalbackgroundsList(mPatient);
            patientService.SavePersonalBackgroundList(patientPersonalBackgrounds);

            var patientMotherBackgrounds = setMotherbackgroundsList(mPatient);
            patientService.SaveMotherBackgroundList(patientMotherBackgrounds);

            var patientFatherBackgrounds = setFatherbackgroundsList(mPatient);
            patientService.SaveFatherBackgroundList(patientFatherBackgrounds);
            return responsePatient;
        }

        [HttpPost]
        [Route("patient/{id:int}")]
        public HttpResponseMessage Create(models.Patient mPatient, long id)
        {
            HttpResponseMessage response = null;
            try
            {

                var patient = setPatientInfo(mPatient);
                if (userService.IsUserAlreadyExist(patient.user) && !mPatient.IsEdit)
                {
                    response = Request.CreateResponse(HttpStatusCode.Conflict, "User Already Exist");
                 
                }
                else
                {
                    patient.id = id;
                    var responsePatient = patientService.SavePatient(patient);
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
        [Authorize(Roles = "admin")]
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
        [Route("~/api/department/{id:int}/provinces")]
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
        [Route("~/api/province/{id:int}/districts")]
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
        [Authorize]
        [Route("~/api/record/patient")]
        public HttpResponseMessage GetPatient(int documentNumber)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var currentLoggedInUser = userService.GetCurrentUser(principal);

            Domain.Patient pat = patientService.GetPatientByDocumentNumber(documentNumber);
            


            //if medic check access 
            if(currentLoggedInUser.roleId == 2)
            {
                var permission = patientService.checkMedicAccessForPatientData(pat.id);
                if(permission != null && !permission.is_medic_authorized)
                {
                    Domain.Patient limitedDataPat = new Domain.Patient
                    {
                        patientMedicPermission = pat.patientMedicPermission,
                        user = new Domain.User
                        {
                            id = pat.user.id,
                            documentNumber = pat.user.documentNumber,
                            email = pat.user.email,
                            firstName = pat.user.firstName,
                            lastNameFather = pat.user.lastNameFather,
                            lastNameMother = pat.user.lastNameMother,
                            roleId = pat.user.roleId,
                            role = new Role
                            {
                                id = pat.user.role.id,
                                name = pat.user.role.name,
                                description = pat.user.role.description
                            }
                        }
                    };
                    return  Request.CreateResponse(HttpStatusCode.OK, new { patient = limitedDataPat});
                }
            }

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


        [HttpGet]
        [Route("GetPatientSymptoms")]
        public HttpResponseMessage GetSymptoms()
        {
            //Domain.User pat = patientService.GetPatientByDocumentNumber(documentNumber);
           var symptoms = patientService.GetAllSymptoms();

            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new { symptoms = symptoms});
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("RequestAccess")]
        public HttpResponseMessage RequestPatientAccess(int userId)
        {
            var user = this.userService.GetUserById(userId);
            HttpResponseMessage response = null;
            try
            {
                var accountSettingPage = Infrastructure.SecurityHelper.GetAccountSettingLink(Request);
                var emailBody = emailService.GetEmailBody(EmailPurpose.PatientDataAccessRequest, accountSettingPage);
                emailService.SendEmailAsync(user.email, "Solicitud de acceso a datos - SolidarityMedical", emailBody, accountSettingPage);
                response = Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("MedicAccessRequests")]
        public HttpResponseMessage MedicAccessRequests(int userId)
        {
            HttpResponseMessage response = null;
            try
            {
                var permissions = patientService.getPermissionRequests(userId);
                response =  Request.CreateResponse(HttpStatusCode.OK, new { permissions = permissions });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("MedicAccessRequestChange")]
        public HttpResponseMessage MedicAccessRequests(PatientMedicPermission medicPermission)
        {
            HttpResponseMessage response = null;
            try
            {
                patientService.ChangeMedicAccess(medicPermission);
                var permissions = patientService.getPermissionRequests(medicPermission.user_id);
                response = Request.CreateResponse(HttpStatusCode.OK, new { permissions = permissions });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Authorize]
        [Route("GetSymptomsByPatientID")]
        public HttpResponseMessage GetSymptomsByPatient(string documentNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var symptoms = patientService.GetSymptomsByPatientId(documentNumber);
                response = Request.CreateResponse(HttpStatusCode.OK, new { symptoms = symptoms });
            }
            catch (Exception ex)
            {
                //response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                response = Request.CreateResponse(HttpStatusCode.OK);

            }
            return response;


        }

        [HttpPost]
        [Route("SavePatientSymptoms")]
        public HttpResponseMessage SaveSymptoms(SymptomsWithCustom symptoms)
        {
            //Domain.User pat = patientService.GetPatientByDocumentNumber(documentNumber);
            var result = patientService.SaveSymptoms(symptoms);

            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new { success = result});
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

        public Domain.Patient setPatientInfo(models.Patient mPatient)
        {
            Domain.Patient patient = new Domain.Patient();
            patient.id = mPatient.id;
            patient.alcohol = mPatient.alcoholConsumption;
            patient.bloodType = mPatient.bloodType;
            patient.cigaretteNumber = mPatient.cigarettes;
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
            patient.departmentId = mPatient.department;
            patient.race = mPatient.race;
            patient.user = setUserInfo(mPatient);
            return patient;
        }

        public Domain.User setUserInfo(models.Patient mPatient)
        {
            
            var userData = getUserInfo();
            Domain.User user = new Domain.User();
            user.id = mPatient.userId;
            user.address = mPatient.address;
            user.birthday = mPatient.birthday;
            user.phone = mPatient.phone;
            
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
            user.departmentId = mPatient.department;
            user.provinceId = mPatient.province;

            //Patient Ger Role ID = 4

            user.roleId = 4;
            //user.role

            //if (userData != null)
            //{
            //    user.roleId = userData.roleId;
            //    user.role = userData.role;
            //}
            return user;
        }
        public Domain.User getUserInfo()
        {
            var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            if (headerValues != null)
            {
                string email = Convert.ToString(headerValues.FirstOrDefault());
                return userService.GetByEmail(email);
            }
            else
            {
                return null;
            }
        }

        public List<Domain.PatientAllergies> setAllergyList(models.Patient patient)
        {
            List<Domain.PatientAllergies> lstAllergies = new List<Domain.PatientAllergies>();
            Domain.PatientAllergies allergies;
            if (patient.allergies.Length > 0)
            {
                foreach (var item in patient.allergies)
                {
                    allergies = new Domain.PatientAllergies();
                    allergies.patientId = patient.id;
                    allergies.allergies = item.name;
                    allergies.id = item.id;
                    allergies.isDeleted = item.isDeleted;
                    lstAllergies.Add(allergies);
                }
            }
            return lstAllergies;
        }
        public List<Domain.PatientMedicines> setMedicinesList(models.Patient patient)
        {
            List<Domain.PatientMedicines> lstMedicines = new List<Domain.PatientMedicines>();
            Domain.PatientMedicines medicines;
            if (patient.medicines.Length > 0)
            {
                foreach (var item in patient.medicines)
                {
                    medicines = new Domain.PatientMedicines();
                    medicines.patientId = patient.id;
                    medicines.medicines = item.name;
                    medicines.id = item.id;
                    medicines.isDeleted = item.isDeleted;
                    lstMedicines.Add(medicines);
                }
            }
            return lstMedicines;
        }
        public List<Domain.PatientMotherbackgrounds> setMotherbackgroundsList(models.Patient patient)
        {
            List<Domain.PatientMotherbackgrounds> lstMotherbackgrounds = new List<Domain.PatientMotherbackgrounds>();
            Domain.PatientMotherbackgrounds mBackground;
            if (patient.motherBackground.Length > 0)
            {
                foreach (var item in patient.motherBackground)
                {
                    mBackground = new Domain.PatientMotherbackgrounds();
                    mBackground.patientId = patient.id;
                    mBackground.motherBackgrounds = item.name;
                    mBackground.id = item.id;
                    mBackground.isDeleted = item.isDeleted;
                    lstMotherbackgrounds.Add(mBackground);
                }
            }
            return lstMotherbackgrounds;
        }
        public List<Domain.PatientFatherbackgrounds> setFatherbackgroundsList(models.Patient patient)
        {
            List<Domain.PatientFatherbackgrounds> lstFatherbackgrounds = new List<Domain.PatientFatherbackgrounds>();
            Domain.PatientFatherbackgrounds fBackground;
            if (patient.fatherBackground.Length > 0)
            {
                foreach (var item in patient.fatherBackground)
                {
                    fBackground = new Domain.PatientFatherbackgrounds();
                    fBackground.patientId = patient.id;
                    fBackground.fatherBackgrounds = item.name;
                    fBackground.id = item.id;
                    fBackground.isDeleted = item.isDeleted;
                    lstFatherbackgrounds.Add(fBackground);
                }
            }
            return lstFatherbackgrounds;
        }
        public List<Domain.PatientPersonalBackgrounds> setPersonalbackgroundsList(models.Patient patient)
        {
            List<Domain.PatientPersonalBackgrounds> lstPersonalbackgrounds = new List<Domain.PatientPersonalBackgrounds>();
            Domain.PatientPersonalBackgrounds pBackground;
            if (patient.personalBackground.Length > 0)
            {
                foreach (var item in patient.personalBackground)
                {
                    pBackground = new Domain.PatientPersonalBackgrounds();
                    pBackground.patientId = patient.id;
                    pBackground.personalBackgrounds = item.name;
                    pBackground.id = item.id;
                    pBackground.isDeleted = item.isDeleted;
                    lstPersonalbackgrounds.Add(pBackground);
                }
            }
            return lstPersonalbackgrounds;
        }

       
    }
}
