using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class EstablishmentRepository : IEstablishmentRepository
    {
        public List<Establishment> GetAllEstablishment()
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from c in context.establishments
                        where c.deleted != bytes
                        select new Establishment()
                        {
                            Deleted = c.deleted,
                            Name = c.name,
                            Id = c.id,
                            Address = c.address,
                            EstablishmentType = c.establishmentType,
                            Initials=c.initials,
                            Phone=c.phone
                        }).OrderBy(x => x.Name).ToList();
            }
        }
        public Establishment SaveEstablishment(Establishment mEstablishment)
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efEstablishments = context.establishments.Where(m => m.id == mEstablishment.Id && m.deleted != bytes).FirstOrDefault();
                if (efEstablishments == null)
                {
                    efEstablishments = new DataAccess.establishment();
                    efEstablishments.deleted = BitConverter.GetBytes(false);
                    context.establishments.Add(efEstablishments);
                }
                efEstablishments.name = mEstablishment.Name;
                efEstablishments.address = mEstablishment.Address;
                efEstablishments.initials = mEstablishment.Initials;
                efEstablishments.phone = mEstablishment.Phone;
                efEstablishments.establishmentType = mEstablishment.EstablishmentType;
                context.SaveChanges();
                mEstablishment.Id = efEstablishments.id;
            }
            return mEstablishment;
        }
        public Establishment GetEstablishmentById(long id)
        {
            var bytes = BitConverter.GetBytes(true);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.establishments.Where(x => x.id == id && x.deleted != bytes)
                   .Select(x => new Establishment()
                   {
                       Id = x.id,
                       Name = x.name,
                       Deleted = x.deleted,
                       Address = x.address,
                       Initials = x.initials,
                       EstablishmentType=x.establishmentType,
                       Phone=x.phone
                   }).FirstOrDefault();
            }
        }
        public bool DeleteEstablishmentById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.registroclinicoEntities())
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
