using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class PatientAllergy
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public string Allergies { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
