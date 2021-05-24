using System.Collections.Generic;
using Data.Model;

namespace Repository.IRepository
{
    public interface IDistrictRepository
    {
        List<District> GetAllDistrict();
        District SaveDistrict(District mDistrict);
        District GetDistrictById(long id);
        bool DeleteDistrictById(long id);
    }
}
