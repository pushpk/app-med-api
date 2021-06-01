using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class exam
    {
        public exam()
        {
            noteexams = new HashSet<noteexam>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public string type { get; set; }

        public virtual ICollection<noteexam> noteexams { get; set; }
    }
}
