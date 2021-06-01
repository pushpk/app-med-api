using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class district
    {
        public district()
        {
            users = new HashSet<user>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public long? ubigeo { get; set; }
        public long province_id { get; set; }

        public virtual province province { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
