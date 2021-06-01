using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class notediagnosis
    {
        public long id { get; set; }
        public bool deleted { get; set; }
        public string diagnosisType { get; set; }
        public long? diagnosis_id { get; set; }
        public long? note_id { get; set; }

        public virtual diagnosis diagnosis { get; set; }
        public virtual note note { get; set; }
    }
}
