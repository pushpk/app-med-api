using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class PatientSymptom
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public long? SymptomsId { get; set; }
        public string CustomSymptom { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Symptom Symptoms { get; set; }
    }
}
