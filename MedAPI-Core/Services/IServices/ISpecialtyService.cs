using System.Collections.Generic;

namespace Services.IServices
{
    public interface ISpecialtyService
    {
        List<string> SearchByName(string name);
        List<string> GetAllSpecialty();
    }
}
