using Data.DataModels;
using Repository.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly registroclinicocoreContext context;
        public SpecialtyRepository(registroclinicocoreContext context)
        {
            this.context = context;

        }
      
        public List<Speciality> SearchByName(string name)
        {
            
                return context.specialities.Where(x => x.name.Contains(name))
                     .Select(x => new Speciality()
                     {
                         id = x.id,
                         name = x.name

                     }).ToList();
            
        }
    }
}

