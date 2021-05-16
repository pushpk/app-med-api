using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Nurse
    {
        public string MedicRegistration { get; set; }
        public long Id { get; set; }

        public virtual User IdNavigation { get; set; }
    }
}
