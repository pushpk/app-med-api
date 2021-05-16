using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Country
    {
        public Country()
        {
            Departments = new HashSet<Department>();
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
