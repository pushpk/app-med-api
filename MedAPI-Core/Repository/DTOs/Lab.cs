using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
   public class Lab
    {
        public Lab()
        {
            user = new User();
        }

        public long id { get; set; }

        public string parentCompany { get; set; }
        public string labName { get; set; }
        public long ruc { get; set; }

        public long userId { get; set; }

        public User user { get; set; }
        public bool IsApproved { get; set; }
        public bool IsFreezed { get; set; }
        public bool IsDenied { get; set; }
    }
}
