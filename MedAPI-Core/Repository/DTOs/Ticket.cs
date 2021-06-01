using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
   public class Ticket
    {
        public long id { get; set; }
        public bool closed { get; set; }
        public bool deleted { get; set; }
        public string nroTicket { get; set; }
        public string serie { get; set; }
        public string status { get; set; }

        public virtual ICollection<Note> notes { get; set; }
        public virtual ICollection<Triage> triages { get; set; }
    }
}
