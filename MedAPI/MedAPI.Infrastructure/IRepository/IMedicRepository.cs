using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IRepository
{
   public interface IMedicRepository
    {
        List<Medic> GetAllMedic();
        Medic GetMedicById(long id);
        bool DeleteMedicById(long id);
        long SaveMedic(Medic mMedic);
    }
}
