using Data.DataModels;

using Repository.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly registroclinicocoreContext context;
        public CountryRepository(registroclinicocoreContext context)
        {
            this.context = context;

        }
        public Country GetByName(string name)
        {
            
                return context.countries.Where(x => x.name == name)
                   .Select(x => new Country()
                   {
                       id = x.id,
                       name = x.name,
                       deleted = x.deleted,
                       departments = x.departments.Select(c => new Department()
                       {
                           country_id = c.country_id,
                           id = c.id,
                           name = c.name,
                           deleted = c.deleted
                       }).ToList()
                   }).FirstOrDefault();
           
        }
        public List<Country> GetAllCountry()
        {
            //var bytes = BitConverter.GetBytes(true);
           
                return (from c in context.countries
                        where c.deleted != true
                        select new Country()
                        {
                            deleted = c.deleted,
                            name = c.name,
                            id = c.id,
                            departments = c.departments.Select(x=>new Department()
                            {
                                country_id=x.country_id,
                                id=x.id,
                                name=x.name,
                                deleted=x.deleted
                            }).ToList()
                            
                        }).OrderBy(x => x.name).ToList();
            
        }
        public Country GetCountryById(long id)
        {
            //var bytes = BitConverter.GetBytes(true);
           
                return context.countries.Where(x => x.id == id && x.deleted != true)
                   .Select(x => new Country()
                   {
                       id = x.id,
                       name = x.name,
                       departments = x.departments.Select(c => new Department()
                       {
                           country_id = c.country_id,
                           id = c.id,
                           name = c.name,
                           deleted = c.deleted
                       }).ToList(),
                       deleted = x.deleted,

                   }).FirstOrDefault();
            
        }
        public bool DeleteCountryById(long id)
        {
            bool isSuccess = false;
           
                var efCountries = context.countries.Where(m => m.id == id).FirstOrDefault();
                if (efCountries != null)
                {
                    efCountries.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            
        }
        public Country SaveCountry(Country mCountry)
        {
            
                var efCountries = context.countries.Where(m => m.id == mCountry.id).FirstOrDefault();
                if (efCountries == null)
                {
                    efCountries = new country();
                    efCountries.deleted = true;// BitConverter.GetBytes(false);
                    context.countries.Add(efCountries);
                }
                efCountries.name = mCountry.name;
                context.SaveChanges();
                mCountry.id = efCountries.id;
            
            return mCountry;
        }
    }
}

