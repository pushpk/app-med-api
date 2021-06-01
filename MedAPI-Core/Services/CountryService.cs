using Repository.DTOs;
using Repository.IRepository;
using Services.IServices;
using System.Collections.Generic;

namespace Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public Country GetByName(string name)
        {
            return countryRepository.GetByName(name);
        }

        public List<Country> GetAllCountry()
        {
            return countryRepository.GetAllCountry();
        }

        public Country GetCountryById(long id)
        {
            return countryRepository.GetCountryById(id);
        }

        public bool DeleteCountryById(long id)
        {
            return countryRepository.DeleteCountryById(id);
        }
        public Country SaveCountry(Country mCountry)
        {
            return countryRepository.SaveCountry(mCountry);
        }
    }
}
