using System.Collections.Generic;
using MedAPI.Domain;

namespace MedAPI.Infrastructure.IRepository
{
    public interface INurseRepository
    {
        List<Nurse> GetAll();
        NurseSpecialties GetNurseSpecialtiesById(long id);
        Nurse GetNurseById(long id);
        void SaveNurse(Nurse mNurse);
        void SaveSpecialtie(NurseSpecialties mNurseSpecialties);
    }
}
