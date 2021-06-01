using Repository.DTOs;
using System.Collections.Generic;

namespace Services.IServices
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
