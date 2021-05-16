using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public bool Deletable { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
