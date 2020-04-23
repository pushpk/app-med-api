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
    public class DocumentTypeService : IDocumentTypeService
    {
        public List<string> GetAllDocumentType()
        {
            List<string> documentTypeList = new List<string>();
            Type enumType = typeof(Common.DocumentType);
            Type descriptionAttributeType = typeof(DescriptionAttribute);
            foreach (string memberName in Common.Specialty.GetNames(enumType))
            {
                var member = enumType.GetMember(memberName).Single();

                string memberDescription = ((DescriptionAttribute)Attribute.GetCustomAttribute(member, descriptionAttributeType)).Description;
                documentTypeList.Add(memberDescription);
            }
            return documentTypeList;
        }
    }
}
