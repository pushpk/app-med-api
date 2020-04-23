using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Medicine
    {
        public long Id { get; set; }
        public string Concentration { get; set; }
        public byte[] Deleted { get; set; }
        public string Form { get; set; }
        public long? Fractions { get; set; }
        public string HealthRegistration { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Presentation { get; set; }
    }
}
