using System.Collections.Generic;
using Repository.DTOs;

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
