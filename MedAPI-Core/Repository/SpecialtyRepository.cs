using Data.Model;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
       
        public List<Speciality> SearchByName(string name)
        {
            using (var context = new registroclinicocoreContext())
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

