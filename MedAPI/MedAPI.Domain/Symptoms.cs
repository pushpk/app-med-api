using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
    public class Symptoms
    {
        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }

        public virtual ICollection<PatientSymptoms> patient_symptoms { get; set; }

    }
}
