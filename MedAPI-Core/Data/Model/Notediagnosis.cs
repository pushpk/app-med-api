using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Notediagnosis
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string DiagnosisType { get; set; }
        public long? DiagnosisId { get; set; }
        public long? NoteId { get; set; }

        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Note Note { get; set; }
    }
}
