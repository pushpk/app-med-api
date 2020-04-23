using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class NoteExam
    {
        public NoteExam()
        {
            this.Notes = new List<Note>();
            this.Uploads = new List<Upload>();
        }

        public long Id { get; set; }
        public byte[] Deleted { get; set; }
        public string Observation { get; set; }
        public string Specification { get; set; }
        public string Status { get; set; }
        public long ExamId { get; set; }
        public long NoteId { get; set; }
        public List<Note> Notes { get; set; }
        public List<Upload> Uploads { get; set; }
    }
}
