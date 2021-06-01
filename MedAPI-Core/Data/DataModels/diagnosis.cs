using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class diagnosis
    {
        public diagnosis()
        {
            notediagnoses = new HashSet<notediagnosis>();
        }

        public long id { get; set; }
        public string code { get; set; }
        public bool deleted { get; set; }
        public string title { get; set; }
        public long chapter_id { get; set; }

        public virtual chapter chapter { get; set; }
        public virtual ICollection<notediagnosis> notediagnoses { get; set; }
    }
}
