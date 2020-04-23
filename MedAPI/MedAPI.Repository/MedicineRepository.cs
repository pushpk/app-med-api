using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        public bool DeleteMedicineById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efMedicine = context.medicines.Where(m => m.id == id).FirstOrDefault();
                if (efMedicine != null)
                {
                    efMedicine.deleted = BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<Medicine> GetAllMedicine()
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from me in context.medicines
                        where me.deleted != bytes
                        select new Medicine()
                        {
                            Id = me.id,
                            Concentration = me.concentration,
                            Form = me.form,
                            Fractions = me.fractions,
                            HealthRegistration = me.healthRegistration,
                            Name = me.name,
                            Owner = me.owner,
                            Presentation = me.presentation
                        }).ToList();
            }
        }

        public Medicine GetMedicineById(long id)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.medicines.Where(x => x.id == id && x.deleted != null)
                   .Select(x => new Medicine()
                   {
                       Id = x.id,
                       Concentration = x.concentration,
                       Form = x.form,
                       Fractions = x.fractions,
                       HealthRegistration = x.healthRegistration,
                       Name = x.name,
                       Owner = x.owner,
                       Presentation = x.presentation
                   }).FirstOrDefault();
            }
        }

        public int SaveMedicine(Medicine mMedicine)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efMedicine = context.medicines.Where(x => x.id == mMedicine.Id).FirstOrDefault();
                if (efMedicine == null)
                {
                    efMedicine = new DataAccess.medicine();
                    context.medicines.Add(efMedicine);
                }
                efMedicine.name = mMedicine.Name;
                efMedicine.concentration = mMedicine.Concentration;
                efMedicine.form = mMedicine.Form;
                efMedicine.fractions = mMedicine.Fractions;
                efMedicine.healthRegistration = mMedicine.HealthRegistration;
                efMedicine.owner = mMedicine.Owner;
                efMedicine.presentation = mMedicine.Presentation;
                context.SaveChanges();
                return Convert.ToInt32(efMedicine.id);
            }
        }

        public List<Medicine> SearchByName(string name)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.medicines.Where(x => x.name.Contains(name) && x.deleted != null)
                     .Select(x => new Medicine()
                     {
                         Id = x.id,
                         Concentration = x.concentration,
                         Form = x.form,
                         Fractions = x.fractions,
                         HealthRegistration = x.healthRegistration,
                         Name = x.name,
                         Owner = x.owner,
                         Presentation = x.presentation
                     }).ToList();
            }
        }
    }
}
