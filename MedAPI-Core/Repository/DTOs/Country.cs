using Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
   public class Country
    {
        public Country()
        {
            //this.departments = new HashSet<department>();
            this.users = new HashSet<user>();
            departments = new List<Department>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public List<Department> departments { get; set; }
        //public virtual ICollection<department> departments { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
