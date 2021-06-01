using Repository.DTOs;
using System.Collections.Generic;

namespace Services.IServices
{
    public interface INurseService
    {
        List<Nurse> GetAll();
        Nurse GetNurseById(long id);
        Nurse SaveNurse(Nurse mNurse);
    }
}
