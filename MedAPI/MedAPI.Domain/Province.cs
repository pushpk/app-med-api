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
            this.districts = new List<District>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string name { get; set; }
        public long departmentId { get; set; }
        public List<District> districts { get; set; }
    }
}
