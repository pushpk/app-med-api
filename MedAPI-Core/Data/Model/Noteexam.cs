using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Noteexam
    {
        public Noteexam()
        {
            NoteexamUploads = new HashSet<NoteexamUpload>();
        }

        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Observation { get; set; }
        public string Specification { get; set; }
        public string Status { get; set; }
        public long ExamId { get; set; }
        public long NoteId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Note Note { get; set; }
        public virtual ICollection<NoteexamUpload> NoteexamUploads { get; set; }
    }
}
