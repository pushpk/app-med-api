using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Province
    {
        public Province()
        {
            Districts = new HashSet<District>();
        }

        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public long DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
