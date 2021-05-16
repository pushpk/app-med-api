using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class NurseSpecialty
    {
        public long NurseId { get; set; }
        public string Specialties { get; set; }

        public virtual Nurse Nurse { get; set; }
    }
}
