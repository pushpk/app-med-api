using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedAPI.Repository
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
       
        public List<Speciality> SearchByName(string name)
        {
            using (var context = new DataAccess.registroclinicoEntities())
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
}

