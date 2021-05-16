using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Medicine
    {
        public Medicine()
        {
            Notemedicines = new HashSet<Notemedicine>();
        }

        public long Id { get; set; }
        public string Concentration { get; set; }
        public bool Deleted { get; set; }
        public string Form { get; set; }
        public long? Fractions { get; set; }
        public string HealthRegistration { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Presentation { get; set; }

        public virtual ICollection<Notemedicine> Notemedicines { get; set; }
    }
}
