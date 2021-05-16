using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Notereferral
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Reason { get; set; }
        public string Specialty { get; set; }
        public long? NoteId { get; set; }

        public virtual Note Note { get; set; }
    }
}
