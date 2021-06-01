using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Services.Helpers;
using Services.IServices;

namespace Services
{
    public class PermissionService : IPermissionService
    {
        public List<string> GetAllPermission()
        {
            List<string> permissionList = new List<string>();
            Type enumType = typeof(Common.Permission);
            Type descriptionAttributeType = typeof(DescriptionAttribute);
            foreach (string memberName in Common.Permission.GetNames(enumType))
            {
                var member = enumType.GetMember(memberName).Single();

                string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
                permissionList.Add(memberDescription);
            }
            return permissionList;
        }
    }
}
