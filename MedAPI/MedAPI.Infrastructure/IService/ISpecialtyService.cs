using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface ISpecialtyService
    {
        List<string> SearchByName(string name);
        List<string> GetAllSpecialty();
    }
}
