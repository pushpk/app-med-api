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
            //this.notes = new List<Note>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string diagnosisType { get; set; }
        public long? diagnosisId { get; set; }
        public long? noteId { get; set; }

        //public List<Note> notes { get; set; }
    }
}
