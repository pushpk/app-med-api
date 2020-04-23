using System.Collections.Generic;

namespace MedAPI.Domain
{
    public class Establishment
    {
        public Establishment()
        {
            this.Notes = new List<Note>();
        }

        public long Id { get; set; }
        public string Address { get; set; }
        public byte[] Deleted { get; set; }
        public string EstablishmentType { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public List<Note> Notes { get; set; }
    }
}
