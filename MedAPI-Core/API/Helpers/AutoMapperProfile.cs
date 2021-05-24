
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
            
            CreateMap<API.Models.Allergy, Data.Model.PatientAllergy>();
            CreateMap<API.Models.Medicine, Data.Model.PatientMedicine>();


            CreateMap<API.Models.PersonalBackground, Data.Model.PatientPersonalbackground>();
            CreateMap<API.Models.FatherBackground, Data.Model.PatientFatherbackground>();
            CreateMap<API.Models.MotherBackground, Data.Model.PatientMotherbackground>();


            CreateMap<API.Models.User, Data.Model.User>();
            CreateMap<API.Models.Patient, Data.Model.Patient>()
                    .ForMember(dest => dest.DepartmentId,
                  opt => opt.MapFrom(src => src.department))
                    .ForMember(dest => dest.Department,
                  opt => opt.Ignore()); ;

        }
    }
}
