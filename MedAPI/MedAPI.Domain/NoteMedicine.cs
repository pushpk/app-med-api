using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class NoteMedicine
    {
        public NoteMedicine()
        {
            this.Notes = new List<Note>();
        }

        public long Id { get; set; }
        public byte[] Deleted { get; set; }
        public long DurationTime { get; set; }
        public string DurationUnit { get; set; }
        public long? FrequencyTime { get; set; }
        public string FrequencyUnit { get; set; }
        public string Indication { get; set; }
        public long? MedicineId { get; set; }
        public long? NoteId { get; set; }

        public List<Note> Notes { get; set; }
    }
}
