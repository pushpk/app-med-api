using System;

namespace Repository.DTOs
{
    public class PatientSymptoms
    {
        public long id { get; set; }
        public long patient_id { get; set; }
        public Nullable<long> symptoms_id { get; set; }
        public string custom_symptom { get; set; }

        public virtual Patient patient { get; set; }
        public virtual Symptoms symptom { get; set; }
    }
}