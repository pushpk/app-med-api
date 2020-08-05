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
            //this.notes = new List<Note>();
            this.medicineList = new List<Medicine>();
        }

        public long id { get; set; }
        public byte[] deleted { get; set; }
        public long? durationTime { get; set; }
        public string durationUnit { get; set; }
        public long? frequencyTime { get; set; }
        public string frequencyUnit { get; set; }
        public string indication { get; set; }
        public long? medicineId { get; set; }
        public long? noteId { get; set; }
        public List<Medicine> medicineList { get; set; }
        //public List<Note> notes { get; set; }
    }
}
