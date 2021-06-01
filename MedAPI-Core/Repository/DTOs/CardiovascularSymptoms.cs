using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
    public class CardiovascularSymptoms
    {
        public long id { get; set; }
        public long cardiovascularNoteId { get; set; }
        public string cardiovascularSymptoms { get; set; }
        public bool isDelete { get; set; }
    }
}
