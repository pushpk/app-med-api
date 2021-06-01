using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class medicine
    {
        public medicine()
        {
            notemedicines = new HashSet<notemedicine>();
        }

        public long id { get; set; }
        public string concentration { get; set; }
        public bool deleted { get; set; }
        public string form { get; set; }
        public long? fractions { get; set; }
        public string healthRegistration { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public string presentation { get; set; }

        public virtual ICollection<notemedicine> notemedicines { get; set; }
    }
}
