using System.Collections.Generic;
using Repository.DTOs;

namespace Repository.IRepository
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
