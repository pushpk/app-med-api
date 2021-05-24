using Data.Model;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class NurseRepository : INurseRepository
    {
        public List<Nurse> GetAll()
        {
            using (var context = new registroclinicocoreContext())
            {
                return (from n in context.nurses
                        select new Nurse()
                        {
                            id = n.id,
                            medicRegistration = n.medicRegistration,
                        }).ToList();
            }
        }
        public NurseSpecialties GetNurseSpecialtiesById(long id)
        {
            using (var context = new registroclinicocoreContext())
            {
                return (from n in context.nurse_specialties
                        select new NurseSpecialties
                        {
                            nurseId = n.Nurse_id,
                            specialties = n.specialties
                        }).FirstOrDefault();
            }
        }

        public Nurse GetNurseById(long id)
        {
            using (var context = new registroclinicocoreContext())
            {
                return (from n in context.nurses
                        select new Nurse()
                        {
                            id = n.id,
                            medicRegistration = n.medicRegistration,
                        }).FirstOrDefault();
            }
        }

        public void SaveNurse(Nurse mNurse)
        {
            using (var context = new registroclinicocoreContext())
            {
                var efNurse = context.nurses.Where(m => m.id == mNurse.id).FirstOrDefault();
                if (efNurse == null)
                {
                    efNurse = new DataAccess.nurse();
                    context.nurses.Add(efNurse);
                }
                efNurse.id = mNurse.id;
                efNurse.medicRegistration = mNurse.medicRegistration;
                context.SaveChanges();
            }
        }
        public void SaveSpecialtie(NurseSpecialties mNurseSpecialties)
        {
            using (var context = new registroclinicocoreContext())
            {
                var efNurseSpecialties = context.nurse_specialties.Where(m => m.Nurse_id == mNurseSpecialties.nurseId).FirstOrDefault();
                if (efNurseSpecialties == null)
                {
                    efNurseSpecialties = new DataAccess.nurse_specialties();
                    context.nurse_specialties.Add(efNurseSpecialties);
                }
                efNurseSpecialties.Nurse_id = mNurseSpecialties.nurseId;
                efNurseSpecialties.specialties = mNurseSpecialties.specialties;
                context.SaveChanges();
            }
        }
    }
}
