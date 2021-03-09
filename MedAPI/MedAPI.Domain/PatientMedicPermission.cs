using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
    public class PatientMedicPermission
    {
            public long user_id{ get; set; }
            public long patient_id { get; set; }
            public long medic_id { get; set; }
            public bool is_medic_authorized { get; set; }
            public bool is_future_request_blocked { get; set; }
        public  Domain.Medic medic { get; set; }



    }
}
