using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Medicine
    {
        public long id { get; set; }
        public string concentration { get; set; }
        public bool deleted { get; set; }
        public string form { get; set; }
        public long? fractions { get; set; }
        public string healthRegistration { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public string presentation { get; set; }
    }
}
