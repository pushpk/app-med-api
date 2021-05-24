using Data.Model;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DistrictRepository : IDistrictRepository
    {
        public List<District> GetAllDistrict()
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new registroclinicocoreContext())
            {
                return (from c in context.districts
                        where c.deleted != true
                        select new District()
                        {
                            deleted = c.deleted,
                            name = c.name,
                            id = c.id,
                            provinceId = c.province_id,
                            ubigeo = c.ubigeo,
                        }).OrderBy(x => x.name).ToList();
            }
        }
        public District SaveDistrict(District mDistrict)
        {
            //var bytes= BitConverter.GetBytes(true);
            using (var context = new registroclinicocoreContext())
            {
                var efDisrict = context.districts.Where(m => m.id == mDistrict.id && m.deleted != true).FirstOrDefault();
                if (efDisrict == null)
                {
                    efDisrict = new DataAccess.district();
                    efDisrict.deleted = false;// BitConverter.GetBytes(false);
                    context.districts.Add(efDisrict);
                }
                efDisrict.name = mDistrict.name;
                efDisrict.province_id = mDistrict.provinceId;
                efDisrict.ubigeo = mDistrict.ubigeo;
                context.SaveChanges();
                mDistrict.id = efDisrict.id;
            }
            return mDistrict;
        }
        public District GetDistrictById(long id)
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new registroclinicocoreContext())
            {
                return context.districts.Where(x => x.id == id && x.deleted != true)
                   .Select(x => new District()
                   {
                       id = x.id,
                       name = x.name,
                       deleted = x.deleted,
                       provinceId = x.province_id,
                       ubigeo = x.ubigeo
                   }).FirstOrDefault();
            }
        }
        public bool DeleteDistrictById(long id)
        {
            bool isSuccess = false;
            using (var context = new registroclinicocoreContext())
            {
                var efDistricts = context.districts.Where(m => m.id == id).FirstOrDefault();
                if (efDistricts != null)
                {
                    efDistricts.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }
    }
}
