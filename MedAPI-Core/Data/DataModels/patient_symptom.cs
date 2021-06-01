using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class patient_symptom
    {
        public long id { get; set; }
        public long patient_id { get; set; }
        public long? symptoms_id { get; set; }
        public string custom_symptom { get; set; }

        public virtual patient patient { get; set; }
        public virtual symptom symptoms { get; set; }
    }
}
