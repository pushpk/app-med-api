using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class user : IdentityUser<long>
    {
        public user()
        {
            lab_upload_results = new HashSet<lab_upload_result>();
            labs = new HashSet<lab>();
            notes = new HashSet<note>();
            patients = new HashSet<patient>();
        }

        
        public string address { get; set; }
        public DateTime birthday { get; set; }
        public string cellphone { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public bool deletable { get; set; }
        public bool deleted { get; set; }
        public string documentNumber { get; set; }
        public string documentType { get; set; }
        
        public string firstName { get; set; }
        public string lastNameFather { get; set; }
        public string lastNameMother { get; set; }
        public string maritalStatus { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public bool organDonor { get; set; }
        public string password_hash { get; set; }
        public string phone { get; set; }
        public string sex { get; set; }
        public DateTime since { get; set; }
        public long country_id { get; set; }
        public long? district_id { get; set; }
        public long? role_id { get; set; }
        public long? department_id { get; set; }
        public long? province_id { get; set; }
        public Guid token { get; set; }
        
        public Guid reset_token { get; set; }

        public virtual country country { get; set; }
        public virtual department department { get; set; }
        public virtual district district { get; set; }
        public virtual role role { get; set; }
        public virtual medic medic { get; set; }
        public virtual nurse nurse { get; set; }
        public virtual ICollection<lab_upload_result> lab_upload_results { get; set; }
        public virtual ICollection<lab> labs { get; set; }
        public virtual ICollection<note> notes { get; set; }
        public virtual ICollection<patient> patients { get; set; }
    }
}
