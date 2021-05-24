using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
   public interface ICountryRepository
    {
        Country GetByName(string name);
        List<Country> GetAllCountry();
        Country GetCountryById(long id);
        bool DeleteCountryById(long id);
        Country SaveCountry(Country mCountry);
    }
}
