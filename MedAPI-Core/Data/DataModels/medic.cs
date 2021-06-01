using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class medic
    {
        public medic()
        {
            lab_upload_results = new HashSet<lab_upload_result>();
            notes = new HashSet<note>();
            patient_medic_permissions = new HashSet<patient_medic_permission>();
        }

        public string cmp { get; set; }
        public string rne { get; set; }
        public long id { get; set; }
        public bool IsFreezed { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDenied { get; set; }

        public virtual user idNavigation { get; set; }
        public virtual medic_specialty medic_specialty { get; set; }
        public virtual ICollection<lab_upload_result> lab_upload_results { get; set; }
        public virtual ICollection<note> notes { get; set; }
        public virtual ICollection<patient_medic_permission> patient_medic_permissions { get; set; }
    }
}
