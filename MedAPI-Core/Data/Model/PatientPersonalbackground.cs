using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class PatientPersonalbackground
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public string PersonalBackgrounds { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
