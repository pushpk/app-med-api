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
                        where p.id==id
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
                        where c.deleted != bytes && c.province_id==id
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

        //public Patient GetPatientByDocumentNumber(string documentNumber)
        //{
        //    using (var context = new DataAccess.RegistroclinicoEntities())
        //    {
        //        return (from p in context.patients
        //                where p.docu == documentNumber
        //                select new Patient
        //                {
        //                    Id = p.id,
        //                    Alcohol = p.alcohol,
        //                    BloodType = p.bloodType,
        //                    CigaretteNumber = p.cigaretteNumber,
        //                    CreatedTicket = p.createdTicket,
        //                    DormNumber = p.dormNumber,
        //                    EducationalAttainment = p.educationalAttainment,
        //                    Electricity = p.electricity,
        //                    FractureNumber = p.fractureNumber,
        //                    FruitsVegetables = p.fruitsVegetables,
        //                    HighGlucose = p.highGlucose,
        //                    HomeMaterial = p.homeMaterial,
        //                    HomeOwnership = p.homeOwnership,
        //                    HomeType = p.homeType,
        //                    Occupation = p.occupation,
        //                    OtherAllergies = p.otherAllergies,
        //                    OtherFatherBackground = p.otherFatherBackground,
        //                    OtherMedicines = p.otherMedicines,
        //                    OtherMotherBackground = p.otherMotherBackground,
        //                    OtherPersonalBackground = p.otherPersonalBackground,
        //                    PhysicalActivity = p.physicalActivity,
        //                    ResidentNumber = p.residentNumber,
        //                    Sewage = p.sewage,
        //                    Water = p.water
        //                }).FirstOrDefault();
        //    }
        //}

    }
}
