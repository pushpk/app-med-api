using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class nurse_specialty
    {
        public long Nurse_id { get; set; }
        public string specialties { get; set; }

        public virtual nurse Nurse { get; set; }
    }
}
