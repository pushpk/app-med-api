//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedAPI.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public long id { get; set; }
        public string address { get; set; }
        public System.DateTime birthday { get; set; }
        public string cellphone { get; set; }
        public string createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public byte[] deletable { get; set; }
        public byte[] deleted { get; set; }
        public string documentNumber { get; set; }
        public string documentType { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastNameFather { get; set; }
        public string lastNameMother { get; set; }
        public string maritalStatus { get; set; }
        public string modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedDate { get; set; }
        public byte[] organDonor { get; set; }
        public string password_hash { get; set; }
        public string phone { get; set; }
        public string sex { get; set; }
        public System.DateTime since { get; set; }
        public long country_id { get; set; }
        public Nullable<long> district_id { get; set; }
        public Nullable<long> role_id { get; set; }
    
        public virtual country country { get; set; }
        public virtual district district { get; set; }
        public virtual medic medic { get; set; }
        public virtual nurse nurse { get; set; }
        public virtual patient patient { get; set; }
        public virtual role role { get; set; }
    }
}
