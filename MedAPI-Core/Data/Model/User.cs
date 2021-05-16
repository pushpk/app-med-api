using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class User
    {
        public User()
        {
            LabUploadResults = new HashSet<LabUploadResult>();
            Labs = new HashSet<Lab>();
            Notes = new HashSet<Note>();
            Patients = new HashSet<Patient>();
        }

        public long Id { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Cellphone { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Deletable { get; set; }
        public bool Deleted { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastNameFather { get; set; }
        public string LastNameMother { get; set; }
        public string MaritalStatus { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool OrganDonor { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public DateTime Since { get; set; }
        public long CountryId { get; set; }
        public long? DistrictId { get; set; }
        public long? RoleId { get; set; }
        public long? DepartmentId { get; set; }
        public long? ProvinceId { get; set; }
        public Guid Token { get; set; }
        public bool EmailConfirmed { get; set; }
        public Guid ResetToken { get; set; }

        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }
        public virtual District District { get; set; }
        public virtual Role Role { get; set; }
        public virtual Medic Medic { get; set; }
        public virtual Nurse Nurse { get; set; }
        public virtual ICollection<LabUploadResult> LabUploadResults { get; set; }
        public virtual ICollection<Lab> Labs { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
