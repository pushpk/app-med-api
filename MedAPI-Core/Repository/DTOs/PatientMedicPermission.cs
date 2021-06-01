using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
    public class PatientMedicPermission
    {
            public long user_id{ get; set; }
            public long patient_id { get; set; }
            public long medic_id { get; set; }
            public bool is_medic_authorized { get; set; }
            public bool is_future_request_blocked { get; set; }
        public  Medic medic { get; set; }
        public bool is_request_sent { get; set; }
    }
}
