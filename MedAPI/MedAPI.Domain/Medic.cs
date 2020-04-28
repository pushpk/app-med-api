using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Medic
    {
        public Medic()
        {
            this.Notes = new List<Note>();
            User = new User();
        }

        public string Cmp { get; set; }
        public string Rne { get; set; }
        public long Id { get; set; }
        public User User { get; set; }
        public List<Note> Notes { get; set; }
    }
}
