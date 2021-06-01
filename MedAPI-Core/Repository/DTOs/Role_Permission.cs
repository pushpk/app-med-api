using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
   public class Role_Permission
    {
        public long role_id { get; set; }
        public string permissions { get; set; }

        public virtual Role role { get; set; }
    }
}
