using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class symptom
    {
        public symptom()
        {
            patient_symptoms = new HashSet<patient_symptom>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }

        public virtual ICollection<patient_symptom> patient_symptoms { get; set; }
    }
}
