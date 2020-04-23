using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System.Collections.Generic;

namespace MedAPI.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;
        private readonly IProvinceRepository provinceRepository;
        public PatientService(IPatientRepository patientRepository, IProvinceRepository provinceRepository)
        {
            this.patientRepository = patientRepository;
            this.provinceRepository = provinceRepository;

        }

        public List<Patient> GetAllPatient()
        {
            return patientRepository.GetAllPatient();
        }

        public Patient GetPatientById(long id)
        {
            return patientRepository.GetPatientById(id);
        }
        public bool DeletePatientById(long id)
        {
            return patientRepository.DeletePatientById(id);
        }
        public List<Province> GetProvinceByDepartment(long id)
        {
          return  provinceRepository.GetAllProvinceByDeparmentId(id);
        }
        public List<District> GetDistrictByprovinceId(long id)
        {
            return patientRepository.GetDistrictByprovinceId(id);
        }
        //public Patient GetPatientByDocumentNumber(string documentNumber)
        //{
        //    return patientRepository.GetPatientByDocumentNumber(documentNumber);
        //}
    }
}
