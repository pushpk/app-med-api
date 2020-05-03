﻿using MedAPI.Domain;
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
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from p in context.patients
                        select new Patient()
                        {
                            Id = p.id,
                            Alcohol = p.alcohol,
                            BloodType = p.bloodType,
                            CigaretteNumber = p.cigaretteNumber,
                            CreatedTicket = p.createdTicket,
                            DormNumber = p.dormNumber,
                            EducationalAttainment = p.educationalAttainment,
                            Electricity = p.electricity,
                            FractureNumber = p.fractureNumber,
                            FruitsVegetables = p.fruitsVegetables,
                            HighGlucose = p.highGlucose,
                            HomeMaterial = p.homeMaterial,
                            HomeOwnership = p.homeOwnership,
                            HomeType = p.homeType,
                            Occupation = p.occupation,
                            OtherAllergies = p.otherAllergies,
                            OtherFatherBackground = p.otherFatherBackground,
                            OtherMedicines = p.otherMedicines,
                            OtherMotherBackground = p.otherMotherBackground,
                            OtherPersonalBackground = p.otherPersonalBackground,
                            PhysicalActivity = p.physicalActivity,
                            ResidentNumber = p.residentNumber,
                            Sewage = p.sewage,
                            Water = p.water
                        }).ToList();
            }
        }

        public Patient GetPatientById(long id)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from p in context.patients
                        where p.id == id
                        select new Patient
                        {
                            Id = p.id,
                            Alcohol = p.alcohol,
                            BloodType = p.bloodType,
                            CigaretteNumber = p.cigaretteNumber,
                            CreatedTicket = p.createdTicket,
                            DormNumber = p.dormNumber,
                            EducationalAttainment = p.educationalAttainment,
                            Electricity = p.electricity,
                            FractureNumber = p.fractureNumber,
                            FruitsVegetables = p.fruitsVegetables,
                            HighGlucose = p.highGlucose,
                            HomeMaterial = p.homeMaterial,
                            HomeOwnership = p.homeOwnership,
                            HomeType = p.homeType,
                            Occupation = p.occupation,
                            OtherAllergies = p.otherAllergies,
                            OtherFatherBackground = p.otherFatherBackground,
                            OtherMedicines = p.otherMedicines,
                            OtherMotherBackground = p.otherMotherBackground,
                            OtherPersonalBackground = p.otherPersonalBackground,
                            PhysicalActivity = p.physicalActivity,
                            ResidentNumber = p.residentNumber,
                            Sewage = p.sewage,
                            Water = p.water
                        }).FirstOrDefault();
            }
        }

        public bool DeletePatientById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.RegistroclinicoEntities())
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
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from c in context.districts
                        where c.deleted != bytes && c.province_id == id
                        select new District()
                        {
                            Deleted = c.deleted,
                            Name = c.name,
                            Id = c.id,
                            ProvinceId = c.province_id,
                            Ubigeo = c.ubigeo,
                        }).OrderBy(x => x.Name).ToList();
            }
        }

        public void SavePatient(Patient mPatient)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efPatients = context.patients.Where(m => m.id == mPatient.Id).FirstOrDefault();
                if (efPatients == null)
                {
                    efPatients = new DataAccess.patient();
                    context.patients.Add(efPatients);
                }
                efPatients.id = mPatient.Id;
                efPatients.alcohol = mPatient.Alcohol;
                efPatients.bloodType = mPatient.BloodType;
                efPatients.cigaretteNumber = mPatient.CigaretteNumber;
                efPatients.createdTicket = mPatient.CreatedTicket;
                efPatients.dormNumber = mPatient.DormNumber;
                efPatients.educationalAttainment = mPatient.EducationalAttainment;
                efPatients.electricity = mPatient.Electricity;
                efPatients.fractureNumber = mPatient.FractureNumber;
                efPatients.fruitsVegetables = mPatient.FruitsVegetables;
                efPatients.highGlucose = mPatient.HighGlucose;
                efPatients.homeMaterial = mPatient.HomeMaterial;
                efPatients.homeOwnership = mPatient.HomeOwnership;
                efPatients.homeType = mPatient.HomeType;
                efPatients.occupation = mPatient.Occupation;
                efPatients.otherAllergies = mPatient.OtherAllergies;
                efPatients.otherFatherBackground = mPatient.OtherFatherBackground;
                efPatients.otherMedicines = mPatient.OtherMedicines;
                efPatients.otherMotherBackground = mPatient.OtherMotherBackground;
                efPatients.otherPersonalBackground = mPatient.OtherPersonalBackground;
                efPatients.physicalActivity = mPatient.PhysicalActivity;
                efPatients.residentNumber = mPatient.ResidentNumber;
                efPatients.sewage = mPatient.Sewage;
                efPatients.water = mPatient.Water;
                context.SaveChanges();
            }
        }

        public User GetPatientByDocumentNumber(int documentNumber)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from x in context.users
                        where x.documentNumber == documentNumber.ToString()
                        select new User
                        {
                            Id = x.id,
                            Address = x.address,
                            Birthday = x.birthday,
                            Cellphone = x.cellphone,
                            CountryId = x.country_id,
                            CreatedBy = x.createdBy,
                            CreatedDate = x.createdDate,
                            DistrictId = x.district_id,
                            DocumentNumber = x.documentNumber,
                            DocumentType = x.documentType,
                            Email = x.email,
                            FirstName = x.firstName,
                            LastNameFather = x.lastNameFather,
                            MaritalStatus = x.maritalStatus,
                            LastNameMother = x.lastNameFather,
                            ModifiedBy = x.modifiedBy,
                            ModifiedDate = x.modifiedDate,
                            OrganDonor = x.organDonor,
                            Phone = x.phone,
                            RoleId = x.role_id,
                            Since = x.since,
                            PasswordHash = x.password_hash,
                            Role = new Role
                            {
                                Id = x.role.id,
                                Name = x.role.name,
                                Description = x.role.description
                            },
                            Sex = x.sex
                        }).FirstOrDefault();
            }
        }

    }
}
