using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            Notediagnoses = new HashSet<Notediagnosis>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public bool Deleted { get; set; }
        public string Title { get; set; }
        public long ChapterId { get; set; }

        public virtual Chapter Chapter { get; set; }
        public virtual ICollection<Notediagnosis> Notediagnoses { get; set; }
    }
}
