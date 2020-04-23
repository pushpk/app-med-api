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
    public class BloodTypeService : IBloodTypeService
    {
        public List<string> GetAllBloodType()
        {
            List<string> bloodTypeList = new List<string>();
            Type enumType = typeof(Common.BloodType);
            Type descriptionAttributeType = typeof(DescriptionAttribute);
            foreach (string memberName in Common.BloodType.GetNames(enumType))
            {
                var member = enumType.GetMember(memberName).Single();

                string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
                bloodTypeList.Add(memberDescription);
            }
            return bloodTypeList;
        }
    }
}
