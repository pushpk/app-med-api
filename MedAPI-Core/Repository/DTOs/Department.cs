using Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
   public class Department
    {
        public Department()
        {
            this.provinces = new List<province>();
        }


        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public long country_id { get; set; }

        public virtual Country country { get; set; }
        public virtual ICollection<province> provinces { get; set; }
    }
}
