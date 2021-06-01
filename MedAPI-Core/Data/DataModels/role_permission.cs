using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class role_permission
    {
        public long Role_id { get; set; }
        public string permissions { get; set; }

        public virtual role Role { get; set; }
    }
}
