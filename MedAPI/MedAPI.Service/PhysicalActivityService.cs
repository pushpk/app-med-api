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
    public class PhysicalActivityService : IPhysicalActivityService
    {
        public List<string> GetAllPhysicalActivity()
        {
            List<string> physicalActivityList = new List<string>();
            Type enumType = typeof(Common.PhysicalActivity);
            Type descriptionAttributeType = typeof(DescriptionAttribute);
            foreach (string memberName in Common.PhysicalActivity.GetNames(enumType))
            {
                var member = enumType.GetMember(memberName).Single();

                string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
                physicalActivityList.Add(memberDescription);
            }
            return physicalActivityList;
        }
    }
}
