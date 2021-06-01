using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class patient_medic_permission
    {
        public long patient_id { get; set; }
        public long medic_id { get; set; }
        public bool is_medic_authorized { get; set; }
        public bool is_future_request_blocked { get; set; }
        public bool is_request_sent { get; set; }

        public virtual medic medic { get; set; }
        public virtual patient patient { get; set; }
    }
}
