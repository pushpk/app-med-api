using System.Collections.Generic;
using Data.Model;

namespace Repository.IRepository
{
    public interface INurseRepository
    {
        List<Nurse> GetAll();
        NurseSpecialty GetNurseSpecialtiesById(long id);
        Nurse GetNurseById(long id);
        void SaveNurse(Nurse mNurse);
        void SaveSpecialtie(NurseSpecialty mNurseSpecialties);
    }
}
