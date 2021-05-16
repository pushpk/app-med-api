using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class PatientMotherbackground
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public string MotherBackgrounds { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
