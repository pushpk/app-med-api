using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class PatientMedicPermission
    {
        public long PatientId { get; set; }
        public long MedicId { get; set; }
        public bool IsMedicAuthorized { get; set; }
        public bool IsFutureRequestBlocked { get; set; }
        public bool IsRequestSent { get; set; }

        public virtual Medic Medic { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
