using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.DTOs
{
    public class PatientPersonalBackgrounds
    {
        public long id { get; set; }
        public long patientId { get; set; }
        public string personalBackgrounds { get; set; }
        public bool isDeleted { get; set; }
    }
}