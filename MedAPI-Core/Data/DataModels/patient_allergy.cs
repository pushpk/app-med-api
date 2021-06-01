using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class patient_allergy
    {
        public long id { get; set; }
        public long patient_id { get; set; }
        public string allergies { get; set; }
        public bool isDeleted { get; set; }

        public virtual patient patient { get; set; }
    }
}
