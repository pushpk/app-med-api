using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class chapter
    {
        public chapter()
        {
            diagnoses = new HashSet<diagnosis>();
        }

        public long id { get; set; }
        public string code { get; set; }
        public bool deleted { get; set; }
        public string title { get; set; }

        public virtual ICollection<diagnosis> diagnoses { get; set; }
    }
}
