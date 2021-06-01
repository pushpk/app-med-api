using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class establishment
    {
        public establishment()
        {
            notes = new HashSet<note>();
        }

        public long id { get; set; }
        public string address { get; set; }
        public byte[] deleted { get; set; }
        public string establishmentType { get; set; }
        public string initials { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        public virtual ICollection<note> notes { get; set; }
    }
}
