using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class MedicSpecialty
    {
        public long MedicId { get; set; }
        public string Specialties { get; set; }

        public virtual Medic Medic { get; set; }
    }
}
