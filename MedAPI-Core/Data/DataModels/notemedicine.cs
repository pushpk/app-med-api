using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class notemedicine
    {
        public long id { get; set; }
        public bool deleted { get; set; }
        public long? durationTime { get; set; }
        public string durationUnit { get; set; }
        public long? frequencyTime { get; set; }
        public string frequencyUnit { get; set; }
        public string indication { get; set; }
        public long? medicine_id { get; set; }
        public long? note_id { get; set; }

        public virtual medicine medicine { get; set; }
        public virtual note note { get; set; }
    }
}
