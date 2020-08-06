using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.Domain
{
    public class PatientPersonalBackgrounds
    {
        public long id { get; set; }
        public long patientId { get; set; }
        public string personalBackgrounds { get; set; }
    }
}