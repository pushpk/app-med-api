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
    public class HomeTypeService : IHomeTypeService
    {
        public List<string> GetAllHomeType()
        {
            List<string> homeTypeList = new List<string>();
            Type enumType = typeof(Common.HomeType);
            Type descriptionAttributeType = typeof(DescriptionAttribute);
            foreach (string memberName in Common.HomeType.GetNames(enumType))
            {
                var member = enumType.GetMember(memberName).Single();

                string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
                homeTypeList.Add(memberDescription);
            }
            return homeTypeList;
        }
    }
}
