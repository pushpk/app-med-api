using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Department
    {
        public Department()
        {
            Patients = new HashSet<Patient>();
            Provinces = new HashSet<Province>();
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
