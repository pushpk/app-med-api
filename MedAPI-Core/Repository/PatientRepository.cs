
using Repository.IRepository;
using System;
using System.Collections.Generic;

using System.Linq;
using AutoMapper;
using Repository.DTOs;
using Data.DataModels;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly registroclinicocoreContext context;
        public PatientRepository(registroclinicocoreContext context)
        {
            this.context = context;

        }

        public List<Patient> GetAllPatient()
        {
            var bytes = BitConverter.GetBytes(true);
           
                return (from p in context.patients
                        select new Patient()
                        {
                            id = p.id,
                            userId = p.user_id,
                            alcohol = p.alcohol,
                            bloodType = p.bloodType,
                            race = p.race,
                            cigaretteNumber = p.cigaretteNumber,
                            createdTicket = p.createdTicket,
                            dormNumber = p.dormNumber,
                            educationalAttainment = p.educationalAttainment,
                            electricity = p.electricity,
                            fractureNumber = p.fractureNumber,
                            fruitsVegetables = p.fruitsVegetables,
                            highGlucose = p.highGlucose,
                            homeMaterial = p.homeMaterial,
                            homeOwnership = p.homeOwnership,
                            homeType = p.homeType,
                            occupation = p.occupation,
                            otherAllergies = p.otherAllergies,
                            otherFatherBackground = p.otherFatherBackground,
                            otherMedicines = p.otherMedicines,
                            otherMotherBackground = p.otherMotherBackground,
                            otherPersonalBackground = p.otherPersonalBackground,
                            physicalActivity = p.physicalActivity,
                            residentNumber = p.residentNumber,
                            sewage = p.sewage,
                            water = p.water
                        }).ToList();
            
        }

        public int GetActivePatientCount()
        {
            
                return context.patients.Where(x => x.user.emailConfirmed == true).Count();
            
        }

        public Patient GetPatientById(long id)
        {
           
                return (from p in context.patients
                        where p.user_id == id
                        select new Patient
                        {
                            id = p.id,
                            userId = p.user_id,
                            alcohol = p.alcohol,
                            bloodType = p.bloodType,
                            race = p.race,
                            cigaretteNumber = p.cigaretteNumber,
                            createdTicket = p.createdTicket,
                            dormNumber = p.dormNumber,
                            educationalAttainment = p.educationalAttainment,
                            electricity = p.electricity,
                            fractureNumber = p.fractureNumber,
                            fruitsVegetables = p.fruitsVegetables,
                            highGlucose = p.highGlucose,
                            homeMaterial = p.homeMaterial,
                            homeOwnership = p.homeOwnership,
                            homeType = p.homeType,
                            occupation = p.occupation,
                            otherAllergies = p.otherAllergies,
                            otherFatherBackground = p.otherFatherBackground,
                            otherMedicines = p.otherMedicines,
                            otherMotherBackground = p.otherMotherBackground,
                            otherPersonalBackground = p.otherPersonalBackground,
                            physicalActivity = p.physicalActivity,
                            residentNumber = p.residentNumber,
                            sewage = p.sewage,
                            water = p.water
                        }).FirstOrDefault();
            
        }

        public bool DeletePatientById(long id)
        {
            bool isSuccess = false;
           
                var efPatient = context.patients.Where(m => m.user_id == id).FirstOrDefault();
                if (efPatient != null)
                {
                    context.patients.Remove(efPatient);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            
        }
        public List<District> GetDistrictByprovinceId(long id)
        {
            //var bytes = BitConverter.GetBytes(true);
            
                return (from c in context.districts
                        where c.deleted != true && c.province_id == id
                        select new District()
                        {
                            deleted = c.deleted,
                            name = c.name,
                            id = c.id,
                            provinceId = c.province_id,
                            ubigeo = c.ubigeo,
                        }).OrderBy(x => x.name).ToList();
            
        }

        public void SavePatient(Patient mPatient)
        {
            try
            {


                var efPatients = context.patients.Where(m => m.id == mPatient.id).FirstOrDefault();
                if (efPatients == null)
                {
                    efPatients = new patient();
                    context.patients.Add(efPatients);


                }
                efPatients.id = mPatient.id;
                efPatients.user_id = mPatient.userId;
                efPatients.alcohol = mPatient.alcohol;
                efPatients.bloodType = mPatient.bloodType;
                efPatients.cigaretteNumber = mPatient.cigaretteNumber;
                efPatients.createdTicket = mPatient.createdTicket;
                efPatients.dormNumber = mPatient.dormNumber;
                efPatients.educationalAttainment = mPatient.educationalAttainment;
                efPatients.electricity = mPatient.electricity;
                efPatients.fractureNumber = mPatient.fractureNumber;
                efPatients.fruitsVegetables = mPatient.fruitsVegetables;
                efPatients.highGlucose = mPatient.highGlucose;
                efPatients.homeMaterial = mPatient.homeMaterial;
                efPatients.homeOwnership = mPatient.homeOwnership;
                efPatients.homeType = mPatient.homeType;
                efPatients.occupation = mPatient.occupation;
                efPatients.otherAllergies = mPatient.otherAllergies;
                efPatients.otherFatherBackground = mPatient.otherFatherBackground;
                efPatients.otherMedicines = mPatient.otherMedicines;
                efPatients.otherMotherBackground = mPatient.otherMotherBackground;
                efPatients.otherPersonalBackground = mPatient.otherPersonalBackground;
                efPatients.physicalActivity = mPatient.physicalActivity;
                efPatients.residentNumber = mPatient.residentNumber;
                efPatients.sewage = mPatient.sewage;
                efPatients.departmentId = mPatient.departmentId;
                efPatients.water = mPatient.water;
                efPatients.race = mPatient.race;

                context.SaveChanges();
                mPatient.id = efPatients.id;

            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
        }

        public Patient GetPatientByDocumentNumber(int documentNumber)
        {
           
                var patientFromRepo = context.patients.Where(p => p.user.documentNumber == documentNumber.ToString()).FirstOrDefault();

                if (patientFromRepo == null)
                {
                    return null;
                }
                else
                {
                    var patient = new Patient
                    {
                        id = patientFromRepo.id,
                        userId = patientFromRepo.user_id,
                        alcohol = patientFromRepo.alcohol,
                        bloodType = patientFromRepo.bloodType,
                        race = patientFromRepo.race,
                        cigaretteNumber = patientFromRepo.cigaretteNumber,
                        createdTicket = patientFromRepo.createdTicket,
                        dormNumber = patientFromRepo.dormNumber,
                        educationalAttainment = patientFromRepo.educationalAttainment,
                        electricity = patientFromRepo.electricity,
                        fractureNumber = patientFromRepo.fractureNumber,
                        fruitsVegetables = patientFromRepo.fruitsVegetables,
                        highGlucose = patientFromRepo.highGlucose,
                        homeMaterial = patientFromRepo.homeMaterial,
                        homeOwnership = patientFromRepo.homeOwnership,
                        homeType = patientFromRepo.homeType,
                        occupation = patientFromRepo.occupation,
                        otherAllergies = patientFromRepo.otherAllergies,
                        otherFatherBackground = patientFromRepo.otherFatherBackground,
                        otherMedicines = patientFromRepo.otherMedicines,
                        otherMotherBackground = patientFromRepo.otherMotherBackground,
                        otherPersonalBackground = patientFromRepo.otherPersonalBackground,
                        physicalActivity = patientFromRepo.physicalActivity,
                        residentNumber = patientFromRepo.residentNumber,
                        sewage = patientFromRepo.sewage,
                        water = patientFromRepo.water,
                        departmentId = patientFromRepo.departmentId,
                        patientMedicPermission = ((from y in context.patient_medic_permissions
                                                   where y.patient_id == patientFromRepo.id
                                                   select new PatientMedicPermission()
                                                   {
                                                       patient_id = y.patient_id,
                                                       medic_id = y.medic_id,
                                                       is_medic_authorized = y.is_medic_authorized,
                                                       is_future_request_blocked = y.is_future_request_blocked,
                                                       is_request_sent = y.is_future_request_blocked
                                                   }).ToList()),
                        allergiesList = ((from y in context.patient_allergies
                                          where y.patient_id == patientFromRepo.id && y.isDeleted == false
                                          select new PatientAllergies()
                                          {
                                              id = y.id,
                                              patientId = y.patient_id,
                                              allergies = y.allergies
                                          }).ToList()),
                        medicinesList = ((from y in context.patient_medicines
                                          where y.patient_id == patientFromRepo.id && y.isDeleted == false
                                          select new PatientMedicines()
                                          {
                                              id = y.id,
                                              patientId = y.patient_id,
                                              medicines = y.medicines
                                          }).ToList()),
                        personalBackgroundList = ((from y in context.patient_personalbackgrounds
                                                   where y.patient_id == patientFromRepo.id && y.isDeleted == false
                                                   select new PatientPersonalBackgrounds()
                                                   {
                                                       id = y.id,
                                                       patientId = y.patient_id,
                                                       personalBackgrounds = y.personalBackgrounds
                                                   }).ToList()),
                        patientFatherbackgroundList = ((from y in context.patient_fatherbackgrounds
                                                        where y.patient_id == patientFromRepo.id && y.isDeleted == false
                                                        select new PatientFatherbackgrounds()
                                                        {
                                                            id = y.id,
                                                            patientId = y.patient_id,
                                                            fatherBackgrounds = y.fatherBackgrounds
                                                        }).ToList()),
                        patientMotherbackgroundList = ((from y in context.patient_motherbackgrounds
                                                        where y.patient_id == patientFromRepo.id && y.isDeleted == false
                                                        select new PatientMotherbackgrounds()
                                                        {
                                                            id = y.id,
                                                            patientId = y.patient_id,
                                                            motherBackgrounds = y.motherBackgrounds
                                                        }).ToList()),
                    };

                    var user = (from x in context.users
                                where x.role_id == 4 && x.documentNumber == documentNumber.ToString()
                                select new User
                                {
                                    id = x.id,
                                    address = x.address,
                                    birthday = x.birthday,
                                    cellphone = x.cellphone,
                                    countryId = x.country_id,
                                    deleted = x.deleted,
                                    createdBy = x.createdBy,
                                    createdDate = x.createdDate,
                                    districtId = x.district_id,
                                    departmentId = x.department_id,
                                    provinceId = x.province_id,
                                    documentNumber = x.documentNumber,
                                    documentType = x.documentType,
                                    email = x.email,
                                    firstName = x.firstName,
                                    lastNameFather = x.lastNameFather,
                                    lastNameMother = x.lastNameMother,
                                    maritalStatus = x.maritalStatus,
                                    modifiedBy = x.modifiedBy,
                                    modifiedDate = x.modifiedDate,
                                    organDonor = x.organDonor,
                                    phone = x.phone,
                                    roleId = x.role_id,
                                    since = x.since,
                                    passwordHash = x.password_hash,
                                    role = new Role
                                    {
                                        id = x.role.id,
                                        name = x.role.name,
                                        description = x.role.description
                                    },
                                    sex = x.sex
                                }).FirstOrDefault();

                    patient.user = user;

                    return patient;

                }
            
        }

        public bool SaveAllergiesList(List<PatientAllergies> mAllergies)
        {
           
                try
                {
                    foreach (var allergies in mAllergies)
                    {
                        var efAllergies = context.patient_allergies.Where(m => m.patient_id == allergies.patientId && m.id == allergies.id).FirstOrDefault();
                        if (efAllergies == null)
                        {
                            efAllergies = new patient_allergy();
                            context.patient_allergies.Add(efAllergies);
                        }
                        efAllergies.patient_id = allergies.patientId;
                        efAllergies.allergies = allergies.allergies;
                        efAllergies.isDeleted = allergies.isDeleted;
                        context.SaveChanges();
                        allergies.id = efAllergies.id;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            
        }
        public bool SaveMedicinesList(List<PatientMedicines> mMedicines)
        {
          
                try
                {
                    foreach (var medicines in mMedicines)
                    {
                        var efMedicines = context.patient_medicines.Where(m => m.patient_id == medicines.patientId && m.id == medicines.id).FirstOrDefault();
                        if (efMedicines == null)
                        {
                            efMedicines = new patient_medicine();
                            context.patient_medicines.Add(efMedicines);
                        }
                        efMedicines.patient_id = medicines.patientId;
                        efMedicines.medicines = medicines.medicines;
                        efMedicines.isDeleted = medicines.isDeleted;
                        context.SaveChanges();
                        medicines.id = efMedicines.id;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            
        }
        public bool SavePersonalBackgroundList(List<PatientPersonalBackgrounds> mPersonalBackgrounds)
        {
           
                try
                {
                    foreach (var personalBackgrounds in mPersonalBackgrounds)
                    {
                        var efPersonalBackgrounds = context.patient_personalbackgrounds.Where(m => m.patient_id == personalBackgrounds.patientId && m.id == personalBackgrounds.id).FirstOrDefault();
                        if (efPersonalBackgrounds == null)
                        {
                            efPersonalBackgrounds = new patient_personalbackground();
                            context.patient_personalbackgrounds.Add(efPersonalBackgrounds);
                        }
                        efPersonalBackgrounds.patient_id = personalBackgrounds.patientId;
                        efPersonalBackgrounds.personalBackgrounds = personalBackgrounds.personalBackgrounds;
                        efPersonalBackgrounds.isDeleted = personalBackgrounds.isDeleted;
                        context.SaveChanges();
                        personalBackgrounds.id = efPersonalBackgrounds.id;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            
        }
        public bool SaveMotherBackgroundList(List<PatientMotherbackgrounds> mMotherBackgrounds)
        {
            
                try
                {
                    foreach (var motherBackgrounds in mMotherBackgrounds)
                    {
                        var efMotherBackgrounds = context.patient_motherbackgrounds.Where(m => m.patient_id == motherBackgrounds.patientId && m.id == motherBackgrounds.id).FirstOrDefault();
                        if (efMotherBackgrounds == null)
                        {
                            efMotherBackgrounds = new patient_motherbackground();
                            context.patient_motherbackgrounds.Add(efMotherBackgrounds);
                        }
                        efMotherBackgrounds.patient_id = motherBackgrounds.patientId;
                        efMotherBackgrounds.motherBackgrounds = motherBackgrounds.motherBackgrounds;
                        efMotherBackgrounds.isDeleted = motherBackgrounds.isDeleted;
                        context.SaveChanges();
                        motherBackgrounds.id = efMotherBackgrounds.id;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            
        }
        public bool SaveFatherBackgroundList(List<PatientFatherbackgrounds> mFatherBackgrounds)
        {
           
                try
                {
                    foreach (var fatherBackgrounds in mFatherBackgrounds)
                    {
                        var efFatherBackgrounds = context.patient_fatherbackgrounds.Where(m => m.patient_id == fatherBackgrounds.patientId && m.id == fatherBackgrounds.id).FirstOrDefault();
                        if (efFatherBackgrounds == null)
                        {
                            efFatherBackgrounds = new patient_fatherbackground();
                            context.patient_fatherbackgrounds.Add(efFatherBackgrounds);
                        }
                        efFatherBackgrounds.patient_id = fatherBackgrounds.patientId;
                        efFatherBackgrounds.fatherBackgrounds = fatherBackgrounds.fatherBackgrounds;
                        efFatherBackgrounds.isDeleted = fatherBackgrounds.isDeleted;
                        context.SaveChanges();
                        fatherBackgrounds.id = efFatherBackgrounds.id;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            
        }

        public bool SaveSymptoms(SymptomsWithCustom mSymptoms)
        {
           
                long userId = context.users.FirstOrDefault(s => s.documentNumber == mSymptoms.documentNumber).id;
                long patientId = context.patients.FirstOrDefault(s => s.user_id == userId).id;

                var efSymptomsExisting = context.patient_symptoms.Where(m => m.patient_id == patientId);
                if (efSymptomsExisting != null)
                {
                    context.patient_symptoms.RemoveRange(efSymptomsExisting);
                    context.SaveChanges();
                }

                try
                {
                    foreach (var Symptom in mSymptoms.symptoms)
                    {
                        var efSymptoms = new patient_symptom();
                        context.patient_symptoms.Add(efSymptoms);

                        efSymptoms.patient_id = patientId;
                        efSymptoms.symptoms_id = Symptom.id;
                        efSymptoms.custom_symptom = mSymptoms.Custom_Symptom;

                        context.SaveChanges();
                        Symptom.id = efSymptoms.id;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            
        }


        public SymptomsWithCustom GetSymptomsByPatientId(string docNum)
        {
           
                long userId = context.users.FirstOrDefault(s => s.documentNumber == docNum).id;
                long patientId = context.patients.FirstOrDefault(s => s.user_id == userId).id;

                List<Symptoms> pSym = new List<Symptoms>();
                var ps = context.patient_symptoms.Include("symptom").Where(s => s.patient_id == patientId);
                foreach (var item in ps)
                {
                    pSym.Add(new Symptoms
                    {

                        id = item.symptoms.id,
                        name = item.symptoms.name
                    });

                }

                return new SymptomsWithCustom
                {
                    Custom_Symptom = ps.FirstOrDefault()?.custom_symptom,
                    symptoms = pSym.ToArray()
                };


            
        }

        public List<Symptoms> GetAllSymptoms()
        {
           
                return context.symptoms
                    .Select(s => new Symptoms()
                    {
                        id = s.id,
                        name = s.name,
                        deleted = s.deleted
                    }).ToList();

            
        }

        public PatientMedicPermission checkMedicAccessForPatientData(long id)
        {
           
                var medicPermission = context.patient_medic_permissions.FirstOrDefault(s => s.patient_id == id);
                return medicPermission == null ? new PatientMedicPermission() :

                 new PatientMedicPermission
                 {
                     medic_id = medicPermission.medic_id,
                     patient_id = medicPermission.patient_id,
                     is_medic_authorized = medicPermission.is_medic_authorized,
                     is_future_request_blocked = medicPermission.is_future_request_blocked,
                     is_request_sent = medicPermission.is_request_sent,
                     medic = new Medic
                     {

                         id = medicPermission.medic.id,
                         cmp = medicPermission.medic.cmp,
                         rne = medicPermission.medic.rne,
                         IsApproved = medicPermission.medic.IsApproved,
                         IsFreezed = medicPermission.medic.IsFreezed,
                         user = new User
                         {

                             id = medicPermission.medic.idNavigation.id,
                             address = medicPermission.medic.idNavigation.address,
                             cellphone = medicPermission.medic.idNavigation.cellphone,
                             countryId = medicPermission.medic.idNavigation.country_id,
                             deleted = medicPermission.medic.idNavigation.deleted,
                             createdBy = medicPermission.medic.idNavigation.createdBy,
                             createdDate = medicPermission.medic.idNavigation.createdDate,
                             districtId = medicPermission.medic.idNavigation.district_id,
                             departmentId = medicPermission.medic.idNavigation.department_id,
                             provinceId = medicPermission.medic.idNavigation.province_id,
                             documentNumber = medicPermission.medic.idNavigation.documentNumber,
                             documentType = medicPermission.medic.idNavigation.documentType,
                             email = medicPermission.medic.idNavigation.email,
                             firstName = medicPermission.medic.idNavigation.firstName,
                             lastNameFather = medicPermission.medic.idNavigation.lastNameFather,
                             lastNameMother = medicPermission.medic.idNavigation.lastNameMother,
                             maritalStatus = medicPermission.medic.idNavigation.maritalStatus,
                             modifiedBy = medicPermission.medic.idNavigation.modifiedBy,
                             modifiedDate = medicPermission.medic.idNavigation.modifiedDate,
                             organDonor = medicPermission.medic.idNavigation.organDonor,
                             phone = medicPermission.medic.idNavigation.phone,
                             roleId = medicPermission.medic.idNavigation.role_id,
                             since = medicPermission.medic.idNavigation.since,
                             passwordHash = medicPermission.medic.idNavigation.password_hash


                         }

                     }
                 };
            

        }

        public List<PatientMedicPermission> getPermissionRequests(long userId)
        {
          
                var patient = context.patients.FirstOrDefault(s => s.user_id == userId);
                var permissions = context.patient_medic_permissions.Include("medic").Where(s => s.patient_id == patient.id).ToList();

                List<PatientMedicPermission> convertedPermissions = new List<PatientMedicPermission>();
                try
                {

                    foreach (var medicPermission in permissions)
                    {
                        PatientMedicPermission p = new PatientMedicPermission
                        {
                            medic_id = medicPermission.medic_id,
                            patient_id = patient.id,
                            is_medic_authorized = medicPermission.is_medic_authorized,
                            is_future_request_blocked = medicPermission.is_future_request_blocked,
                            is_request_sent = medicPermission.is_request_sent,
                            medic = new Medic
                            {

                                id = medicPermission.medic.id,
                                cmp = medicPermission.medic.cmp,
                                rne = medicPermission.medic.rne,
                                IsApproved = medicPermission.medic.IsApproved,
                                IsFreezed = medicPermission.medic.IsFreezed,
                                user = new User
                                {

                                    id = medicPermission.medic.idNavigation.id,
                                    address = medicPermission.medic.idNavigation.address,
                                    cellphone = medicPermission.medic.idNavigation.cellphone,
                                    countryId = medicPermission.medic.idNavigation.country_id,
                                    deleted = medicPermission.medic.idNavigation.deleted,
                                    createdBy = medicPermission.medic.idNavigation.createdBy,
                                    createdDate = medicPermission.medic.idNavigation.createdDate,
                                    districtId = medicPermission.medic.idNavigation.district_id,
                                    departmentId = medicPermission.medic.idNavigation.department_id,
                                    provinceId = medicPermission.medic.idNavigation.province_id,
                                    documentNumber = medicPermission.medic.idNavigation.documentNumber,
                                    documentType = medicPermission.medic.idNavigation.documentType,
                                    email = medicPermission.medic.idNavigation.email,
                                    firstName = medicPermission.medic.idNavigation.firstName,
                                    lastNameFather = medicPermission.medic.idNavigation.lastNameFather,
                                    lastNameMother = medicPermission.medic.idNavigation.lastNameMother,
                                    maritalStatus = medicPermission.medic.idNavigation.maritalStatus,
                                    modifiedBy = medicPermission.medic.idNavigation.modifiedBy,
                                    modifiedDate = medicPermission.medic.idNavigation.modifiedDate,
                                    organDonor = medicPermission.medic.idNavigation.organDonor,
                                    phone = medicPermission.medic.idNavigation.phone,
                                    roleId = medicPermission.medic.idNavigation.role_id,
                                    since = medicPermission.medic.idNavigation.since,
                                    passwordHash = medicPermission.medic.idNavigation.password_hash


                                }

                            }
                        };

                        convertedPermissions.Add(p);
                    }

                    return convertedPermissions;
                }
                catch (Exception ex)

                {

                    throw ex;
                }

            

        }

        public bool ChangeMedicAccess(PatientMedicPermission medicPermission)
        {

           
                //user id coming as patient id from UI
                var patient = context.patients.FirstOrDefault(s => s.user_id == medicPermission.user_id);

                var isRequestExist = context.patient_medic_permissions.FirstOrDefault(s => s.patient_id == patient.id && s.medic_id == medicPermission.medic_id);
                bool isMedicAuthrized = medicPermission.is_medic_authorized;
                bool isMedicAuthrizedAndFutureRequests = medicPermission.is_future_request_blocked;
                bool isRequestSent = medicPermission.is_request_sent;

                if (isRequestExist == null)
                {
                    context.patient_medic_permissions.Add(new patient_medic_permission
                    {
                        medic_id = medicPermission.medic_id,
                        patient_id = patient.id,
                        is_medic_authorized = medicPermission.is_medic_authorized,
                        is_future_request_blocked = medicPermission.is_future_request_blocked,
                        is_request_sent = medicPermission.is_request_sent,
                    });
                }
                else
                {
                    isRequestExist.is_medic_authorized = isMedicAuthrized;
                    isRequestExist.is_future_request_blocked = isMedicAuthrizedAndFutureRequests;
                    isRequestExist.is_request_sent = isRequestSent;
                }

                return context.SaveChanges() > 0;
            
        }

        public void InsertOrChangePermissionRequest(long userId, int medicId)
        {
           
                var patient = context.patients.FirstOrDefault(s => s.user_id == userId);
                var permissions = context.patient_medic_permissions.Include("medic").Where(s => s.patient_id == patient.id && s.medic_id == medicId).FirstOrDefault();

                try
                {
                    if (permissions == null)
                    {
                        context.patient_medic_permissions.Add(new patient_medic_permission
                        {
                            medic_id = medicId,
                            patient_id = patient.id,
                            is_medic_authorized = false,
                            is_future_request_blocked = false,
                            is_request_sent = false

                        });

                        context.SaveChanges();
                    }
                }
                catch (Exception ex)

                {
                    throw ex;
                }



            
        }
    }
}
