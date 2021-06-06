using Data.DataModels; using Repository.DTOs;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class NurseRepository : INurseRepository
    {
        private readonly registroclinicocoreContext context;
        public NurseRepository(registroclinicocoreContext context)
        {
            this.context = context;

        }
        public List<Nurse> GetAll()
        {
            
                return (from n in context.nurses
                        select new Nurse()
                        {
                            id = n.id,
                            medicRegistration = n.medicRegistration,
                        }).ToList();
            
        }
        public NurseSpecialties GetNurseSpecialtiesById(long id)
        {
           
                return (from n in context.nurse_specialties
                        select new NurseSpecialties
                        {
                            nurseId = n.Nurse_id,
                            specialties = n.specialties
                        }).FirstOrDefault();
            
        }

        public Nurse GetNurseById(long id)
        {
            
                return (from n in context.nurses
                        select new Nurse()
                        {
                            id = n.id,
                            medicRegistration = n.medicRegistration,
                        }).FirstOrDefault();
            
        }

        public void SaveNurse(Nurse mNurse)
        {
           
                var efNurse = context.nurses.Where(m => m.id == mNurse.id).FirstOrDefault();
                if (efNurse == null)
                {
                    efNurse = new nurse();
                    context.nurses.Add(efNurse);
                }
                efNurse.id = mNurse.id;
                efNurse.medicRegistration = mNurse.medicRegistration;
                context.SaveChanges();
            
        }
        public void SaveSpecialtie(NurseSpecialties mNurseSpecialties)
        {
            
                var efNurseSpecialties = context.nurse_specialties.Where(m => m.Nurse_id == mNurseSpecialties.nurseId).FirstOrDefault();
                if (efNurseSpecialties == null)
                {
                    efNurseSpecialties = new nurse_specialty();
                    context.nurse_specialties.Add(efNurseSpecialties);
                }
                efNurseSpecialties.Nurse_id = mNurseSpecialties.nurseId;
                efNurseSpecialties.specialties = mNurseSpecialties.specialties;
                context.SaveChanges();
            
        }
    }
}
