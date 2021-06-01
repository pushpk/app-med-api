using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class ticket
    {
        public ticket()
        {
            notes = new HashSet<note>();
            triages = new HashSet<triage>();
        }

        public long id { get; set; }
        public bool closed { get; set; }
        public bool deleted { get; set; }
        public string nroTicket { get; set; }
        public string serie { get; set; }
        public string status { get; set; }

        public virtual ICollection<note> notes { get; set; }
        public virtual ICollection<triage> triages { get; set; }
    }
}
