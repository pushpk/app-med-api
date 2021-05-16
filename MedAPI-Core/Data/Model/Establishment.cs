using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Establishment
    {
        public Establishment()
        {
            Notes = new HashSet<Note>();
        }

        public long Id { get; set; }
        public string Address { get; set; }
        public byte[] Deleted { get; set; }
        public string EstablishmentType { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
