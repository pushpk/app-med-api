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
            //this.Notes = new List<Note>();
            this.uploads = new List<Upload>();
            this.examList = new List<Exam>();
        }

        public long id { get; set; }
        public byte[] deleted { get; set; }
        public string observation { get; set; }
        public string specification { get; set; }   
        public string status { get; set; }
        public long examId { get; set; }
        public long noteId { get; set; }
        //public List<Note> Notes { get; set; }
        public List<Upload> uploads { get; set; }
        public List<Exam> examList { get; set; }
    }
}
