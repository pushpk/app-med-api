using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Symptom
    {
        public Symptom()
        {
            PatientSymptoms = new HashSet<PatientSymptom>();
        }

        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PatientSymptom> PatientSymptoms { get; set; }
    }
}
