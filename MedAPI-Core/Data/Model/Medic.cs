using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Medic
    {
        public Medic()
        {
            LabUploadResults = new HashSet<LabUploadResult>();
            Notes = new HashSet<Note>();
            PatientMedicPermissions = new HashSet<PatientMedicPermission>();
        }

        public string Cmp { get; set; }
        public string Rne { get; set; }
        public long Id { get; set; }
        public bool IsFreezed { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDenied { get; set; }

        public virtual User IdNavigation { get; set; }
        public virtual MedicSpecialty MedicSpecialty { get; set; }
        public virtual ICollection<LabUploadResult> LabUploadResults { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<PatientMedicPermission> PatientMedicPermissions { get; set; }
    }
}
