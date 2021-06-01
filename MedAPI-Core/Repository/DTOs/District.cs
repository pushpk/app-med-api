using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
   public class District
    {
        public District()
        {
            this.users = new List<User>();
            province = new Province();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public long? ubigeo { get; set; }
        public long provinceId { get; set; }
        public List<User> users { get; set; }
        public Province province { get; set; }
    }
}
