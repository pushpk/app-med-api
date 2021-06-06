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
using Repository;
using Services.IServices;
using Services.Helpers;
using static Services.Helpers.EmailHelper;
using System.Data.Entity.Validation;

namespace API.Controllers
{

    public class PatientController : BaseController
    {
        
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IPatientService patientService;
        private readonly IEmailService emailService;

        public PatientController(IPatientService patientService, IMapper mapper, IEmailService emailService, IUserService userService)
        {
            this.patientService = patientService;
            this.mapper = mapper;
            this.emailService = emailService;
            this.userService = userService;
        }


        [HttpPost]
        [Route("patient")]
        public ActionResult Create(Patient mPatient)
        {
            try
            {
                var patient = setPatientInfo(mPatient);

                if (userService.IsUserAlreadyExist(patient.user))
                {
                    return BadRequest("User Already Exist");
                }
                else
                {

                    Repository.DTOs.Patient responsePatient = CreatePatient(mPatient);

                    var emailConfirmationLink = SecurityHelper.GetEmailConfirmatioLink(responsePatient.user, Request);
                    var emailBody = emailService.GetEmailBody(EmailPurpose.EmailVerification, emailConfirmationLink);
                    emailService.SendEmailAsync(responsePatient.user.email, "Verifique su Email - SolidarityMedical", emailBody, emailConfirmationLink);

                    return Ok(responsePatient);
                }
            }
            catch (DbEntityValidationException e)
            {
                //var newException = new FormattedDbEntityValidationException(e);
                return BadRequest(e.Message.ToString());
                
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message.ToString());
            }
           
            
        }

        private Repository.DTOs.Patient CreatePatient(Models.Patient mPatient)
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
        private Repository.DTOs.Patient setPatientInfo(Models.Patient mPatient)
        {
            Repository.DTOs.Patient patient = new Repository.DTOs.Patient();
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

        private Repository.DTOs.User setUserInfo(Models.Patient mPatient)
        {

            var userData = getUserInfo();
            Repository.DTOs.User user = new Repository.DTOs.User();
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
        private Repository.DTOs.User getUserInfo()
        {
            //var headerValues = "";
            var email = Request.Headers["email"].ToString();
            if (email != null)
            {
               // string email = Convert.ToString(headerValues.FirstOrDefault());
                return userService.GetByEmail(email);
            }
            else
            {
                return null;
            }
        }


        private List< Repository.DTOs.PatientAllergies> setAllergyList(Models.Patient patient)
        {
            List< Repository.DTOs.PatientAllergies> lstAllergies = new List< Repository.DTOs.PatientAllergies>();
             Repository.DTOs.PatientAllergies allergies;
            if (patient.allergies.Length > 0)
            {
                foreach (var item in patient.allergies)
                {
                    allergies = new  Repository.DTOs.PatientAllergies();
                    allergies.patientId = patient.id;
                    allergies.allergies = item.name;
                    allergies.id = item.id;
                    allergies.isDeleted = item.isDeleted;
                    lstAllergies.Add(allergies);
                }
            }
            return lstAllergies;
        }
        private List< Repository.DTOs.PatientMedicines> setMedicinesList(Models.Patient patient)
        {
            List< Repository.DTOs.PatientMedicines> lstMedicines = new List< Repository.DTOs.PatientMedicines>();
             Repository.DTOs.PatientMedicines medicines;
            if (patient.medicines.Length > 0)
            {
                foreach (var item in patient.medicines)
                {
                    medicines = new  Repository.DTOs.PatientMedicines();
                    medicines.patientId = patient.id;
                    medicines.medicines = item.name;
                    medicines.id = item.id;
                    medicines.isDeleted = item.isDeleted;
                    lstMedicines.Add(medicines);
                }
            }
            return lstMedicines;
        }
        private List< Repository.DTOs.PatientMotherbackgrounds> setMotherbackgroundsList(Models.Patient patient)
        {
            List< Repository.DTOs.PatientMotherbackgrounds> lstMotherbackgrounds = new List< Repository.DTOs.PatientMotherbackgrounds>();
             Repository.DTOs.PatientMotherbackgrounds mBackground;
            if (patient.motherBackground.Length > 0)
            {
                foreach (var item in patient.motherBackground)
                {
                    mBackground = new  Repository.DTOs.PatientMotherbackgrounds();
                    mBackground.patientId = patient.id;
                    mBackground.motherBackgrounds = item.name;
                    mBackground.id = item.id;
                    mBackground.isDeleted = item.isDeleted;
                    lstMotherbackgrounds.Add(mBackground);
                }
            }
            return lstMotherbackgrounds;
        }
        private List<Repository.DTOs.PatientFatherbackgrounds> setFatherbackgroundsList(Models.Patient patient)
        {
            List<Repository.DTOs.PatientFatherbackgrounds> lstFatherbackgrounds = new List<Repository.DTOs.PatientFatherbackgrounds>();
            Repository.DTOs.PatientFatherbackgrounds fBackground;
            if (patient.fatherBackground.Length > 0)
            {
                foreach (var item in patient.fatherBackground)
                {
                    fBackground = new Repository.DTOs.PatientFatherbackgrounds();
                    fBackground.patientId = patient.id;
                    fBackground.fatherBackgrounds = item.name;
                    fBackground.id = item.id;
                    fBackground.isDeleted = item.isDeleted;
                    lstFatherbackgrounds.Add(fBackground);
                }
            }
            return lstFatherbackgrounds;
        }
        private List< Repository.DTOs.PatientPersonalBackgrounds> setPersonalbackgroundsList(Models.Patient patient)
        {
            List< Repository.DTOs.PatientPersonalBackgrounds> lstPersonalbackgrounds = new List< Repository.DTOs.PatientPersonalBackgrounds>();
             Repository.DTOs.PatientPersonalBackgrounds pBackground;
            if (patient.personalBackground.Length > 0)
            {
                foreach (var item in patient.personalBackground)
                {
                    pBackground = new  Repository.DTOs.PatientPersonalBackgrounds();
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
