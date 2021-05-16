using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Upload
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Deleted { get; set; }
        public string Path { get; set; }

        public virtual NoteexamUpload NoteexamUpload { get; set; }
    }
}
