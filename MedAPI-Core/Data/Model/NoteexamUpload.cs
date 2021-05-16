using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class NoteexamUpload
    {
        public long Id { get; set; }
        public long? NoteExamId { get; set; }
        public long? UploadsId { get; set; }

        public virtual Noteexam NoteExam { get; set; }
        public virtual Upload Uploads { get; set; }
    }
}
