using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class country
    {
        public country()
        {
            departments = new HashSet<department>();
            users = new HashSet<user>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }

        public virtual ICollection<department> departments { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
