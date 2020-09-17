using MedAPI.Infrastructure;
using MedAPI.Infrastructure.IService;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MedAPI.Service
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ISpecialtyRepository specialtyRepository;


        public SpecialtyService(ISpecialtyRepository specialtyRepository)
        {
            this.specialtyRepository = specialtyRepository;
        }
        public List<string> GetAllSpecialty()
        {
            List<string> specialtyList = new List<string>();
            Type enumType = typeof(Common.Specialty);
            Type descriptionAttributeType = typeof(DescriptionAttribute);
            foreach (string memberName in Common.Specialty.GetNames(enumType))
            {
                var member = enumType.GetMember(memberName).Single();

                string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
                specialtyList.Add(memberDescription);
            }
            return specialtyList;
        }

        public List<string> SearchByName(string name)
        {

           
            List<string> specialtyList = new List<string>();

            specialtyList = this.specialtyRepository.SearchByName(name).Select(s => s.specialties).ToList();

            //Type enumType = typeof(Common.Specialty);
            //Type descriptionAttributeType = typeof(DescriptionAttribute);
            //foreach (string memberName in Common.Specialty.GetNames(enumType))
            //{
            //    var member = enumType.GetMember(memberName).Single();

            //    string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
            //    specialtyList.Add(memberDescription);
            //}
            //specialtyList = specialtyList.Where(x => x.ToLower().Contains(name.ToLower())).ToList();
            return specialtyList;
        }
    }
}
