using MedAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Department
    {
        public Department()
        {
            this.provinces = new List<province>();
        }


        public long id { get; set; }
        public byte[] deleted { get; set; }
        public string name { get; set; }
        public long country_id { get; set; }

        public virtual Country country { get; set; }
        public virtual ICollection<province> provinces { get; set; }
    }
}
