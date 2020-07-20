using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Nurse
    {
        public Nurse()
        {
            user = new User();
            nurseSpecialties = new NurseSpecialties();
        }
        public string medicRegistration { get; set; }
        public long id { get; set; }

        public Domain.User user  { get; set; }
        public Domain.NurseSpecialties nurseSpecialties { get; set; }
    }
}
