using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface ICountryService
    {
        Country GetByName(string name);
        List<Country> GetAllCountry();
        Country GetCountryById(long id);
        bool DeleteCountryById(long id);
        Country SaveCountry(Country mCountry);
    }
}
