using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class nurse
    {
        public string medicRegistration { get; set; }
        public long id { get; set; }

        public virtual user idNavigation { get; set; }
    }
}
