using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class cardiovascularnote_cardiovascularsymptom
    {
        public long id { get; set; }
        public long cardiovascularNote_id { get; set; }
        public string cardiovascularSymptoms { get; set; }
        public bool isDelete { get; set; }

        public virtual cardiovascularnote cardiovascularNote { get; set; }
    }
}
