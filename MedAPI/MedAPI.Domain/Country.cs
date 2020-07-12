using MedAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Country
    {
        public Country()
        {
            this.departments = new HashSet<department>();
            this.users = new HashSet<user>();
            Departments = new List<Department>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public List<Domain.Department> Departments { get; set; }
        public virtual ICollection<department> departments { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
