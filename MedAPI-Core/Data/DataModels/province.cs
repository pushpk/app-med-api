using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class province
    {
        public province()
        {
            districts = new HashSet<district>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public long department_id { get; set; }

        public virtual department department { get; set; }
        public virtual ICollection<district> districts { get; set; }
    }
}
