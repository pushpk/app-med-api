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
            this.Provinces = new List<Province>();
        }

        public long Id { get; set; }
        public byte[] Deleted { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }
        public List<Province> Provinces { get; set; }
    }
}
