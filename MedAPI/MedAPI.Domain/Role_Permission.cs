using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Role_Permission
    {
        public long Role_id { get; set; }
        public string permissions { get; set; }

        public virtual Role role { get; set; }
    }
}
