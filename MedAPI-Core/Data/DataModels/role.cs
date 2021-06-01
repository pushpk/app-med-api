using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class role
    {
        public role()
        {
            users = new HashSet<user>();
        }

        public long id { get; set; }
        public bool deletable { get; set; }
        public bool deleted { get; set; }
        public string description { get; set; }
        public string name { get; set; }

        public virtual ICollection<user> users { get; set; }
    }
}
