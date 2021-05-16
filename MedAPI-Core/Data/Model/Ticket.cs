using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Ticket
    {
        public Ticket()
        {
            Notes = new HashSet<Note>();
            Triages = new HashSet<Triage>();
        }

        public long Id { get; set; }
        public bool Closed { get; set; }
        public bool Deleted { get; set; }
        public string NroTicket { get; set; }
        public string Serie { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Triage> Triages { get; set; }
    }
}
