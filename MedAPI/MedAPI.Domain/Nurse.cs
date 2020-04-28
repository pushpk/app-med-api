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
            User = new User();
            NurseSpecialties = new NurseSpecialties();
        }
        public string MedicRegistration { get; set; }
        public long Id { get; set; }

        public Domain.User User  { get; set; }
        public Domain.NurseSpecialties NurseSpecialties { get; set; }
    }
}
