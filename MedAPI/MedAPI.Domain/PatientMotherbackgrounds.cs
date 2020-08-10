using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class PatientMotherbackgrounds
    {
        public long id { get; set; }
        public long patientId { get; set; }
        public string motherBackgrounds { get; set; }
        public bool isDeleted { get; set; }
    }
}
