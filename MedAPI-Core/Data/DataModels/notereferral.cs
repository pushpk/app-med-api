using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class notereferral
    {
        public long id { get; set; }
        public bool deleted { get; set; }
        public string reason { get; set; }
        public string specialty { get; set; }
        public long? note_id { get; set; }

        public virtual note note { get; set; }
    }
}
