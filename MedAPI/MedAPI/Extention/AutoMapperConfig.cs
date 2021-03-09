using AutoMapper;
using MedAPI.DataAccess;
using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.Extention
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<User, user>();
            CreateMap<user, User>();
            CreateMap<exam, Exam>();
            CreateMap<medic, Medic> ().ForMember(d => d.user, opt => opt.MapFrom(x => x.user)); ;
            CreateMap<Medic, medic>().ForMember(d => d.user, opt => opt.MapFrom(x => x.user)); ;

            CreateMap<patient, Patient>();
            CreateMap<Patient, patient>();

            CreateMap<patient_symptoms, PatientSymptoms>();
            CreateMap<PatientSymptoms, patient_symptoms>();
            //CreateMap<PatientMedicPermission, patient_medic_permission>().ForMember(d => d.medic, opt => opt.MapFrom(x => x.medic)); 
            //CreateMap<patient_medic_permission, PatientMedicPermission>().ForMember(d => d.medic, opt => opt.MapFrom(x => x.medic));


            CreateMap<PatientMedicPermission, patient_medic_permission>();
            CreateMap<patient_medic_permission, PatientMedicPermission>();

            CreateMap<Symptoms, symptom>().ForMember(d => d.patient_symptoms, opt => opt.MapFrom(x => x.patient_symptoms));
            CreateMap<symptom, Symptoms>().ForMember(d => d.patient_symptoms, opt => opt.MapFrom(x => x.patient_symptoms)); ;




            CreateMap<medicine, Medicine>();
            CreateMap<LabUploadResult, lab_upload_result>();
            CreateMap<lab_upload_result, LabUploadResult>();
        }
    }
}