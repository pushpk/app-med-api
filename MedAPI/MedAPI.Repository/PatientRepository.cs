using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
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
                            alcohol = p.alcohol,
                            bloodType = p.bloodType,
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

        public Patient GetPatientById(long id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from p in context.patients
                        where p.id == id
                        select new Patient
                        {
                            id = p.id,
                            alcohol = p.alcohol,
                            bloodType = p.bloodType,
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
                var efPatient = context.patients.Where(m => m.id == id).FirstOrDefault();
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
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efPatients = context.patients.Where(m => m.id == mPatient.id).FirstOrDefault();
                if (efPatients == null)
                {
                    efPatients = new DataAccess.patient();
                    context.patients.Add(efPatients);
                }
                efPatients.id = mPatient.id;
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
                efPatients.water = mPatient.water;
                context.SaveChanges();
            }
        }

        public Patient GetPatientByDocumentNumber(int documentNumber)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                Patient patient = new Patient();
                var patients = (from x in context.patients
                                where x.user.documentNumber == documentNumber.ToString()
                                select new Patient
                                {
                                    id = x.id,
                                    alcohol = x.alcohol,
                                    bloodType = x.bloodType,
                                    cigaretteNumber = x.cigaretteNumber,
                                    createdTicket = x.createdTicket,
                                    dormNumber = x.dormNumber,
                                    educationalAttainment = x.educationalAttainment,
                                    electricity = x.electricity,
                                    fractureNumber = x.fractureNumber,
                                    fruitsVegetables = x.fruitsVegetables,
                                    highGlucose = x.highGlucose,
                                    homeMaterial = x.homeMaterial,
                                    homeOwnership = x.homeOwnership,
                                    homeType = x.homeType,
                                    occupation = x.occupation,
                                    otherAllergies = x.otherAllergies,
                                    otherFatherBackground = x.otherFatherBackground,
                                    otherMedicines = x.otherMedicines,
                                    otherMotherBackground = x.otherMotherBackground,
                                    otherPersonalBackground = x.otherPersonalBackground,
                                    physicalActivity = x.physicalActivity,
                                    residentNumber = x.residentNumber,
                                    sewage = x.sewage,
                                    water = x.water
                                    //user = x.user
                                    //address = x.address,
                                    //birthday = x.birthday,
                                    //cellphone = x.cellphone,
                                    //countryId = x.country_id,
                                    //deleted = x.deleted,
                                    //createdBy = x.createdBy,
                                    //createdDate = x.createdDate,
                                    //districtId = x.district_id,
                                    //documentNumber = x.documentNumber,
                                    //documentType = x.documentType,
                                    //email = x.email,
                                    //firstName = x.firstName,
                                    //lastNameFather = x.lastNameFather,
                                    //lastNameMother = x.lastNameFather,
                                    //maritalStatus = x.maritalStatus,
                                    //modifiedBy = x.modifiedBy,
                                    //modifiedDate = x.modifiedDate,
                                    //organDonor = x.organDonor,
                                    //phone = x.phone,
                                    //roleId = x.role_id,
                                    //since = x.since,
                                    //passwordHash = x.password_hash,
                                    //role = new Role
                                    //{
                                    //    id = x.role.id,
                                    //    name = x.role.name,
                                    //    description = x.role.description
                                    //},
                                    //sex = x.sex
                                }).FirstOrDefault();

                var users = (from x in context.users
                             where x.documentNumber == documentNumber.ToString()
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
                                 documentNumber = x.documentNumber,
                                 documentType = x.documentType,
                                 email = x.email,
                                 firstName = x.firstName,
                                 lastNameFather = x.lastNameFather,
                                 lastNameMother = x.lastNameFather,
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
                if (patients != null)
                {
                    patient = patients;
                }
                patient.user = users;
                return patient;
            }
        }

    }
}
