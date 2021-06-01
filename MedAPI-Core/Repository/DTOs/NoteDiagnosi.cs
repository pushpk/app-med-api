using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
    public class NoteDiagnosi
    {
        public NoteDiagnosi()
        {
            //this.notes = new List<Note>();
            this.diagnosisList = new List<Diagnosis>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string diagnosisType { get; set; }
        public long? diagnosisId { get; set; }
        public long? noteId { get; set; }
        public List<Diagnosis> diagnosisList { get; set; }
        //public List<Note> notes { get; set; }
    }
}
