using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Lab
    {
        public Lab()
        {
            user = new User();
        }

        public string parentCompany { get; set; }
        public string labName { get; set; }
        public long ruc { get; set; }
        public User user { get; set; }

        
    }
}
