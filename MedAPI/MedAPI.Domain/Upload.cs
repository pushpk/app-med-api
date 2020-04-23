using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Upload
    {
        public Upload()
        {
            this.NoteExams = new List<NoteExam>();
        }

        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public byte[] Deleted { get; set; }
        public string Path { get; set; }

        public List<NoteExam> NoteExams { get; set; }
    }
}
