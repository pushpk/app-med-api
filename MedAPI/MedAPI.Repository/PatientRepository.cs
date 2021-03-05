using MedAPI.Domain;
using MedAPI.DataAccess;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using AutoMapper;

namespace MedAPI.Repository
{
    public class PatientRepository : IPatientRepository
    {
        public List<Patient> GetAllPatient()
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
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
        }

        public int GetActivePatientCount()
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.patients.Where(x => x.user.emailConfirmed == true).Count();
            }
        }

        public Patient GetPatientById(long id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
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
        }

        public bool DeletePatientById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efPatient = context.patients.Where(m => m.user_id == id).FirstOrDefault();
                if (efPatient != null)
                {
                    context.patients.Remove(efPatient);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }
        public List<District> GetDistrictByprovinceId(long id)
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
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
        }

        public void SavePatient(Patient mPatient)
        {
            try
            {

                using (var context = new DataAccess.registroclinicoEntities())
                {
                    var efPatients = context.patients.Where(m => m.id == mPatient.id).FirstOrDefault();
                    if (efPatients == null)
                    {
                        efPatients = new DataAccess.patient();
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
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
        }

        public Patient GetPatientByDocumentNumber(int documentNumber)
        {
            using (var context = new DataAccess.registroclinicoEntities())
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
        }

        public bool SaveAllergiesList(List<PatientAllergies> mAllergies)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                try
                {
                    foreach (var allergies in mAllergies)
                    {
                        var efAllergies = context.patient_allergies.Where(m => m.patient_id == allergies.patientId && m.id == allergies.id).FirstOrDefault();
                        if (efAllergies == null)
                        {
                            efAllergies = new DataAccess.patient_allergies();
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
        }
        public bool SaveMedicinesList(List<PatientMedicines> mMedicines)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                try
                {
                    foreach (var medicines in mMedicines)
                    {
                        var efMedicines = context.patient_medicines.Where(m => m.patient_id == medicines.patientId && m.id == medicines.id).FirstOrDefault();
                        if (efMedicines == null)
                        {
                            efMedicines = new DataAccess.patient_medicines();
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
        }
        public bool SavePersonalBackgroundList(List<PatientPersonalBackgrounds> mPersonalBackgrounds)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                try
                {
                    foreach (var personalBackgrounds in mPersonalBackgrounds)
                    {
                        var efPersonalBackgrounds = context.patient_personalbackgrounds.Where(m => m.patient_id == personalBackgrounds.patientId && m.id == personalBackgrounds.id).FirstOrDefault();
                        if (efPersonalBackgrounds == null)
                        {
                            efPersonalBackgrounds = new DataAccess.patient_personalbackgrounds();
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
        }
        public bool SaveMotherBackgroundList(List<PatientMotherbackgrounds> mMotherBackgrounds)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                try
                {
                    foreach (var motherBackgrounds in mMotherBackgrounds)
                    {
                        var efMotherBackgrounds = context.patient_motherbackgrounds.Where(m => m.patient_id == motherBackgrounds.patientId && m.id == motherBackgrounds.id).FirstOrDefault();
                        if (efMotherBackgrounds == null)
                        {
                            efMotherBackgrounds = new DataAccess.patient_motherbackgrounds();
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
        }
        public bool SaveFatherBackgroundList(List<PatientFatherbackgrounds> mFatherBackgrounds)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                try
                {
                    foreach (var fatherBackgrounds in mFatherBackgrounds)
                    {
                        var efFatherBackgrounds = context.patient_fatherbackgrounds.Where(m => m.patient_id == fatherBackgrounds.patientId && m.id == fatherBackgrounds.id).FirstOrDefault();
                        if (efFatherBackgrounds == null)
                        {
                            efFatherBackgrounds = new DataAccess.patient_fatherbackgrounds();
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
        }

        public bool SaveSymptoms(SymptomsWithCustom mSymptoms)
        {
            using (var context = new DataAccess.registroclinicoEntities())
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
                        var efSymptoms = new DataAccess.patient_symptoms();
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
        }


        public SymptomsWithCustom GetSymptomsByPatientId(string docNum)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                long userId = context.users.FirstOrDefault(s => s.documentNumber == docNum).id;
                long patientId = context.patients.FirstOrDefault(s => s.user_id == userId).id;

                List<Symptoms> pSym = new List<Symptoms>();
                var ps = context.patient_symptoms.Include("symptom").Where(s => s.patient_id == patientId);
                foreach (var item in ps)
                {
                    pSym.Add(new Symptoms
                    {

                        id = item.symptom.id,
                        name = item.symptom.name
                    });

                }

                return new SymptomsWithCustom
                {
                    Custom_Symptom = ps.FirstOrDefault().custom_symptom,
                    symptoms = pSym.ToArray()
                };


            }
        }

        public List<Symptoms> GetAllSymptoms()
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.symptoms
                    .Select(s => new Symptoms() { 
                    id = s.id,
                    name = s.name,
                    deleted = s.deleted
                }).ToList();

            }
        }
    }
}
