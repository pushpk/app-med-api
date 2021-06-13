
using AutoMapper;
using Data.DataModels;
using Repository.DTOs;
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

            CreateMap<User, user>();
              

        }
    }
}
