using Repository.DTOs;
using System;

namespace Repository.DTOs
{
    public class User
    {
        public User()
        {
            role = new Role();
        }
        public long Id { get; set; }
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
        public string lastName { get; set; }
        public string lastNameFather { get; set; }
        public string lastNameMother { get; set; }
        public string maritalStatus { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public bool organDonor { get; set; }

        public string phone { get; set; }
        public string sex { get; set; }
        public DateTime since { get; set; }
        public long countryId { get; set; }
        public long? districtId { get; set; }
        public long? provinceId { get; set; }
        public long? departmentId { get; set; }
        public long? roleId { get; set; }

        public System.Guid token { get; set; }
        public System.Guid reset_token { get; set; }

        //----Identity User Properties
        #region Identity User Props
        public virtual DateTimeOffset? LockoutEnd { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string ConcurrencyStamp { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string NormalizedEmail { get; set; }
        public virtual string Email { get; set; }
        public virtual string NormalizedUserName { get; set; }
        public virtual string UserName { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; } 
        #endregion

        public Medic medic { get; set; }

        public virtual Country country { get; set; }
        public virtual District district { get; set; }
        //public virtual Medic medic { get; set; }
        //public virtual Nurse nurse { get; set; }
        //public virtual Patient patient { get; set; }
        public Role role { get; set; }
    }
}