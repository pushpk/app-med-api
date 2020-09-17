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
       
        public List<MedicSpecialties> SearchByName(string name)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.medic_specialties.Where(x => x.specialties.Contains(name))
                     .Select(x => new MedicSpecialties()
                     {
                         medicId = x.Medic_id,
                         specialties = x.specialties
                         
                     }).ToList();
            }
        }

       
    }
}

