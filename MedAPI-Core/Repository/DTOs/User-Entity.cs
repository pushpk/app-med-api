using Data.DataModels;
using System;

namespace Repository.DTOs
{
    public class UserEn
    {
        public UserEn()
        {
            role = new Role();
        }
        public long id { get; set; }
        public string address { get; set; }
        public DateTime birthday { get; set; }
        public string cellphone { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
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
        public DateTime? modifiedDate { get; set; }
        public byte[] organDonor { get; set; }
        public string passwordHash { get; set; }
        public string phone { get; set; }
        public string sex { get; set; }
        public DateTime since { get; set; }
        public long countryId { get; set; }
        public long? districtId { get; set; }
        public long? roleId { get; set; }


        public virtual Country country { get; set; }
        public virtual District district { get; set; }
        public virtual Medic medic { get; set; }
        public virtual Nurse nurse { get; set; }
        public virtual Patient patient { get; set; }
        public Role role { get; set; }
    }
}
