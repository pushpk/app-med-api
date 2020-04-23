using MedAPI.Infrastructure;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Service
{
    public class EducationService : IEducationService
    {
        public List<string> GetAllEducation()
        {
            List<string> educationList = new List<string>();
            Type enumType = typeof(Common.EducationalAttainment);
            Type descriptionAttributeType = typeof(DescriptionAttribute);
            foreach (string memberName in Common.EducationalAttainment.GetNames(enumType))
            {
                var member = enumType.GetMember(memberName).Single();

                string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
                educationList.Add(memberDescription);
            }
            return educationList;
        }
    }
}
