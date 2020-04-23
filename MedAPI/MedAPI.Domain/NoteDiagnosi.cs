using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class NoteDiagnosi
    {
        public NoteDiagnosi()
        {
            this.Notes = new List<Note>();
        }

        public long Id { get; set; }
        public byte[] Deleted { get; set; }
        public string DiagnosisType { get; set; }
        public long? Diagnosis_id { get; set; }
        public long? NoteId { get; set; }

        public List<Note> Notes { get; set; }
    }
}
