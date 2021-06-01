using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class patient_fatherbackground
    {
        public long id { get; set; }
        public long patient_id { get; set; }
        public string fatherBackgrounds { get; set; }
        public bool isDeleted { get; set; }

        public virtual patient patient { get; set; }
    }
}
