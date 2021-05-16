using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class RolePermission
    {
        public long RoleId { get; set; }
        public string Permissions { get; set; }

        public virtual Role Role { get; set; }
    }
}
