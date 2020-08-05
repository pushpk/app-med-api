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
            this.notes = new List<Note>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string reason { get; set; }
        public string specialty { get; set; }
        public long? noteId { get; set; }

        public List<Note> notes { get; set; }
    }
}
