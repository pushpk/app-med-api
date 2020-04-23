using System;
using System.Collections.Generic;
using System.ComponentModel;
using MedAPI.Infrastructure;
using MedAPI.Infrastructure.IService;
using System.Linq;

namespace MedAPI.Service
{
    public class HomeMaterialService : IHomeMaterialService
    {
        public List<string> GetAllHomeMaterial()
        {
            List<string> homeMaterialList = new List<string>();
            Type enumType = typeof(Common.HomeMaterial);
            Type descriptionAttributeType = typeof(DescriptionAttribute);
            foreach (string memberName in Common.HomeMaterial.GetNames(enumType))
            {
                var member = enumType.GetMember(memberName).Single();

                string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
                homeMaterialList.Add(memberDescription);
            }
            return homeMaterialList;
        }
    }
}
