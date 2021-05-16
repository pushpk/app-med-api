using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Chapter
    {
        public Chapter()
        {
            Diagnoses = new HashSet<Diagnosis>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public bool Deleted { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Diagnosis> Diagnoses { get; set; }
    }
}
