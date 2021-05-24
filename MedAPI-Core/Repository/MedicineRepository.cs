using AutoMapper;
using Data.Model;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        public bool DeleteMedicineById(long id)
        {
            bool isSuccess = false;
            using (var context = new registroclinicocoreContext())
            {
                var efMedicine = context.medicines.Where(m => m.id == id).FirstOrDefault();
                if (efMedicine != null)
                {
                    efMedicine.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<Medicine> GetAllMedicine()
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new registroclinicocoreContext())
            {
                return (from me in context.medicines
                        where me.deleted != true
                        select new Medicine()
                        {
                            id = me.id,
                            concentration = me.concentration,
                            form = me.form,
                            fractions = me.fractions,
                            healthRegistration = me.healthRegistration,
                            name = me.name,
                            owner = me.owner,
                            presentation = me.presentation
                        }).ToList();
            }
        }

        public Medicine GetMedicineById(long id)
        {
            using (var context = new registroclinicocoreContext())
            {
                return context.medicines.Where(x => x.id == id && x.deleted != false)
                   .Select(x => new Medicine()
                   {
                       id = x.id,
                       concentration = x.concentration,
                       form = x.form,
                       fractions = x.fractions,
                       healthRegistration = x.healthRegistration,
                       name = x.name,
                       owner = x.owner,
                       presentation = x.presentation
                   }).FirstOrDefault();
            }
        }

        public int SaveMedicine(Medicine mMedicine)
        {
            using (var context = new registroclinicocoreContext())
            {
                var efMedicine = context.medicines.Where(x => x.id == mMedicine.id).FirstOrDefault();
                if (efMedicine == null)
                {
                    efMedicine = new DataAccess.medicine();
                    efMedicine.deleted = false;// BitConverter.GetBytes(false);
                    context.medicines.Add(efMedicine);
                }
                efMedicine.name = mMedicine.name;
                efMedicine.concentration = mMedicine.concentration;
                efMedicine.form = mMedicine.form;
                efMedicine.fractions = mMedicine.fractions;
                efMedicine.healthRegistration = mMedicine.healthRegistration;
                efMedicine.owner = mMedicine.owner;
                efMedicine.presentation = mMedicine.presentation;
                context.SaveChanges();
                return Convert.ToInt32(efMedicine.id);
            }
        }

        public List<Medicine> SearchByName(string name)
        {
            using (var context = new registroclinicocoreContext())
            {
                var result =  Mapper.Map<List<Medicine>>(context.medicines.Where(x => x.name.Contains(name) && !x.deleted).ToList());
                return result;
            }
        }
    }
}
