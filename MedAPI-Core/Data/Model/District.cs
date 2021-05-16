using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class District
    {
        public District()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public long? Ubigeo { get; set; }
        public long ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
