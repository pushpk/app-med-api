using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
   public class Upload
    {
        public Upload()
        {
            this.noteExams = new List<NoteExam>();
        }

        public long id { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public byte[] deleted { get; set; }
        public string path { get; set; }
        public string filename { get; set; }
        public byte[] fileByte { get; set; }

        public List<NoteExam> noteExams { get; set; }
    }
}
