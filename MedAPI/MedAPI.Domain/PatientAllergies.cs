using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class PatientAllergies
    {
        public long PatientId { get; set; }
        public string Allergies { get; set; }
    }
}
