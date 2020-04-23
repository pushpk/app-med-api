using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Province
    {
        public Province()
        {
            this.Districts = new List<District>();
        }

        public long Id { get; set; }
        public byte[] Deleted { get; set; }
        public string Name { get; set; }
        public long DepartmentId { get; set; }
        public List<District> Districts { get; set; }
    }
}
