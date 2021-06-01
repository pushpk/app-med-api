using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class medic_specialty
    {
        public long Medic_id { get; set; }
        public string specialties { get; set; }

        public virtual medic Medic { get; set; }
    }
}
