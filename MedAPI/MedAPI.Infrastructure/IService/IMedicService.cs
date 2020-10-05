using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IService
{
   public interface IMedicService
    {
        List<Medic> GetAllMedic();
        Medic GetMedicById(long id);
        bool DeleteMedicById(long id);
        Medic SaveMedic(Domain.Medic mMedic);
    }
}
