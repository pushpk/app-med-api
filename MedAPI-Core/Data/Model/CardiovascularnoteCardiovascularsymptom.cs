using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class CardiovascularnoteCardiovascularsymptom
    {
        public long Id { get; set; }
        public long CardiovascularNoteId { get; set; }
        public string CardiovascularSymptoms { get; set; }
        public bool IsDelete { get; set; }

        public virtual Cardiovascularnote CardiovascularNote { get; set; }
    }
}
