using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class department
    {
        public department()
        {
            patients = new HashSet<patient>();
            provinces = new HashSet<province>();
            users = new HashSet<user>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public long country_id { get; set; }

        public virtual country country { get; set; }
        public virtual ICollection<patient> patients { get; set; }
        public virtual ICollection<province> provinces { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
