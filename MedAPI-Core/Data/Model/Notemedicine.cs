using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Notemedicine
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public long? DurationTime { get; set; }
        public string DurationUnit { get; set; }
        public long? FrequencyTime { get; set; }
        public string FrequencyUnit { get; set; }
        public string Indication { get; set; }
        public long? MedicineId { get; set; }
        public long? NoteId { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Note Note { get; set; }
    }
}
