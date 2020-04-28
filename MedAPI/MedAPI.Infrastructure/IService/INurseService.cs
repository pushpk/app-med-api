using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface INurseService
    {
        List<Nurse> GetAll();
        Nurse GetNurseById(long id);
        Nurse SaveNurse(Nurse mNurse);
    }
}
