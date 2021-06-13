
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //CreateMap<API.Models.Allergy, Data.DataModels.PatientAllergy>();
            //CreateMap<API.Models.Medicine, Data.DataModels.PatientMedicine>();


            //CreateMap<API.Models.PersonalBackground, Data.DataModels.PatientPersonalbackground>();
            //CreateMap<API.Models.FatherBackground, Data.DataModels.PatientFatherbackground>();
            //CreateMap<API.Models.MotherBackground, Data.DataModels.PatientMotherbackground>();


            //CreateMap<API.Models.User, Data.Model.User>();
            //CreateMap<API.Models.Patient, Data.Model.Patient>()
            //        .ForMember(dest => dest.DepartmentId,
            //      opt => opt.MapFrom(src => src.department))
            //        .ForMember(dest => dest.Department,
            //      opt => opt.Ignore()); ;

           

        }
    }
}
