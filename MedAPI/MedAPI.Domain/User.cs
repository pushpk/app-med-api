using MedAPI.DataAccess;
using System;

namespace MedAPI.Domain
{
    public class User
    {
        public User()
        {
            Role = new Role();
        }
        public long Id { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Cellphone { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public byte[] Deletable { get; set; }
        public byte[] Deleted { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastNameFather { get; set; }
        public string LastNameMother { get; set; }
        public string MaritalStatus { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] OrganDonor { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public DateTime Since { get; set; }
        public long CountryId { get; set; }
        public long? DistrictId { get; set; }
        public long? RoleId { get; set; }


        public virtual Country country { get; set; }
        public virtual District district { get; set; }
        public virtual Medic medic { get; set; }
        public virtual Nurse nurse { get; set; }
        public virtual Patient patient { get; set; }
        public Role Role { get; set; }
    }
}
