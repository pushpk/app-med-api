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
            this.Departments = new List<Department>();
            this.Users = new List<User>();
        }

        public long Id { get; set; }
        public byte[] Deleted { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public List<User> Users { get; set; }
    }
}
