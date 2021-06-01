using Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
   public interface IMedicService
    {
        List<Medic> GetAllMedic();
        int GetActiveMedicCount();
        Medic GetMedicById(long id);
        bool DeleteMedicById(long id);
        Medic SaveMedic(Medic mMedic);
        Medic UpdateMedic(Medic mMedic);
    }
}
