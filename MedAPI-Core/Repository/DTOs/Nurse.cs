using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
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

        public User user  { get; set; }
        public NurseSpecialties nurseSpecialties { get; set; }
    }
}
