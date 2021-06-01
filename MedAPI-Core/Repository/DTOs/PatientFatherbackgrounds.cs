using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
   public class PatientFatherbackgrounds
    {
        public long id { get; set; }
        public long patientId { get; set; }
        public string fatherBackgrounds { get; set; }
        public bool isDeleted { get; set; }
    }
}
