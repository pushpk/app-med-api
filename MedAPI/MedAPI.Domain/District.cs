using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class District
    {
        public District()
        {
            this.Users = new List<User>();
            Province = new Province();
        }

        public long Id { get; set; }
        public byte[] Deleted { get; set; }
        public string Name { get; set; }
        public long? Ubigeo { get; set; }
        public long ProvinceId { get; set; }
        public List<User> Users { get; set; }
        public Province Province { get; set; }
    }
}
