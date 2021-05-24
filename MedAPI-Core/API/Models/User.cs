using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class User
    {
        public long id { get; set; }
        public string name { get; set; }
        public string lastnameFather { get; set; }
        public string lastnameMother { get; set; }
        public long country { get; set; }
        public string documentType { get; set; }
        public string patientDocumentNumber { get; set; }
        public string documentNumber { get; set; }
        public DateTime birthday { get; set; }
        public string sex { get; set; }
        public string maritalStatus { get; set; }
        public long? district { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public byte[] deletable { get; set; }
        public byte[] deleted { get; set; }

        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public bool isDonor { get; set; }
        public string passwordHash { get; set; }
    }
}