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
    public class HomeOwnershipService : IHomeOwnershipService
    {
        public List<string> GetAllHomeOwnership()
        {
            List<string> homeOwnershipList = new List<string>();
            Type enumType = typeof(Common.HomeOwnership);
            Type descriptionAttributeType = typeof(DescriptionAttribute);
            foreach (string memberName in Common.HomeOwnership.GetNames(enumType))
            {
                var member = enumType.GetMember(memberName).Single();

                string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
                homeOwnershipList.Add(memberDescription);
            }
            return homeOwnershipList;
        }
    }
}
