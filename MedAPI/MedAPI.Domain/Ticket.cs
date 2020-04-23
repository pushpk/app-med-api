using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Ticket
    {
        public long id { get; set; }
        public byte[] closed { get; set; }
        public byte[] deleted { get; set; }
        public string nroTicket { get; set; }
        public string serie { get; set; }
        public string status { get; set; }

        public virtual ICollection<Note> notes { get; set; }
        public virtual ICollection<Triage> triages { get; set; }
    }
}
