using AutoMapper;
using MedAPI.DataAccess;
using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.Security
{
    class UnityConfigProfile : Profile
    {
        public UnityConfigProfile()
        {
            CreateMap<User, user>();
            CreateMap<user, User>();
            CreateMap<exam, Exam>();
            CreateMap<medic, Medic>();
            CreateMap<Medic, medic>();

            CreateMap<patient, Patient>();
            CreateMap<Patient, patient>();

            CreateMap<patient_symptoms, PatientSymptoms>();
            CreateMap<PatientSymptoms, patient_symptoms>();


            CreateMap<Symptoms, symptom>().ForMember(d => d.patient_symptoms, opt => opt.MapFrom(x => x.patient_symptoms));
            CreateMap<symptom, Symptoms>().ForMember(d => d.patient_symptoms, opt => opt.MapFrom(x => x.patient_symptoms)); ;




            CreateMap<medicine, Medicine>();
            CreateMap<LabUploadResult, lab_upload_result>();
            CreateMap<lab_upload_result, LabUploadResult>();
        }
    }
}
