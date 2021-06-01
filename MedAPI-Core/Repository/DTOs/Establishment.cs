using System.Collections.Generic;

namespace Repository.DTOs
{
    public class Establishment
    {
        public Establishment()
        {
            this.notes = new List<Note>();
        }

        public long id { get; set; }
        public string address { get; set; }
        public byte[] deleted { get; set; }
        public string establishmentType { get; set; }
        public string initials { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        public List<Note> notes { get; set; }
    }
}
