﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Services.Helpers;
using Services.IServices;

namespace Services
{
    public class MaritalStatusService : IMaritalStatusService
    {
        public List<string> GetAllMaritalStatus()
        {
            List<string> educationList = new List<string>();
            Type enumType = typeof(Common.MaritalStatus);
            Type descriptionAttributeType = typeof(DescriptionAttribute);
            foreach (string memberName in Common.MaritalStatus.GetNames(enumType))
            {
                var member = enumType.GetMember(memberName).Single();

                string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
                educationList.Add(memberDescription);
            }
            return educationList;
        }
    }
}
