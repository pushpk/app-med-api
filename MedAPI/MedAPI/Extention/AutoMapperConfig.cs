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
            CreateMap<medic, Medic> ();
            CreateMap<Medic, medic>();
            
            CreateMap<medicine, Medicine>();
            CreateMap<LabUploadResult, lab_upload_result>();
            CreateMap<lab_upload_result, LabUploadResult>();
        }
    }
}