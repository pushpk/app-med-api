using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class NoteReferral
    {
        public NoteReferral()
        {
            this.Notes = new List<Note>();
        }

        public long Id { get; set; }
        public byte[] Deleted { get; set; }
        public string Reason { get; set; }
        public string Specialty { get; set; }
        public long? NoteId { get; set; }

        public List<Note> Notes { get; set; }
    }
}
