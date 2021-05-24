using Data.Model;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class EstablishmentRepository : IEstablishmentRepository
    {
        public List<Establishment> GetAllEstablishment()
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new registroclinicocoreContext())
            {
                return (from c in context.establishments
                        where c.deleted != bytes
                        select new Establishment()
                        {
                            deleted = c.deleted,
                            name = c.name,
                            id = c.id,
                            address = c.address,
                            establishmentType = c.establishmentType,
                            initials=c.initials,
                            phone=c.phone
                        }).OrderBy(x => x.name).ToList();
            }
        }
        public Establishment SaveEstablishment(Establishment mEstablishment)
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new registroclinicocoreContext())
            {
                var efEstablishments = context.establishments.Where(m => m.id == mEstablishment.id && m.deleted != bytes).FirstOrDefault();
                if (efEstablishments == null)
                {
                    efEstablishments = new DataAccess.establishment();
                    efEstablishments.deleted = BitConverter.GetBytes(false);
                    context.establishments.Add(efEstablishments);
                }
                efEstablishments.name = mEstablishment.name;
                efEstablishments.address = mEstablishment.address;
                efEstablishments.initials = mEstablishment.initials;
                efEstablishments.phone = mEstablishment.phone;
                efEstablishments.establishmentType = mEstablishment.establishmentType;
                context.SaveChanges();
                mEstablishment.id = efEstablishments.id;
            }
            return mEstablishment;
        }
        public Establishment GetEstablishmentById(long id)
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new registroclinicocoreContext())
            {
                return context.establishments.Where(x => x.id == id && x.deleted != bytes)
                   .Select(x => new Establishment()
                   {
                       id = x.id,
                       name = x.name,
                       deleted = x.deleted,
                       address = x.address,
                       initials = x.initials,
                       establishmentType=x.establishmentType,
                       phone=x.phone
                   }).FirstOrDefault();
            }
        }
        public bool DeleteEstablishmentById(long id)
        {
            bool isSuccess = false;
            using (var context = new registroclinicocoreContext())
            {
                var efEstablishments = context.establishments.Where(m => m.id == id).FirstOrDefault();
                if (efEstablishments != null)
                {
                    efEstablishments.deleted = BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }
    }
}
