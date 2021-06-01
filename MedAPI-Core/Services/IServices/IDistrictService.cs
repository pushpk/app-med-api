using Repository.DTOs;
using System.Collections.Generic;

namespace Services.IServices
{
    public interface IDistrictService
    {
        List<District> GetAllDistrict();
        District SaveDistrict(District mDistrict);
        District GetDistrictById(long id);
        bool DeleteDistrictById(long id);
    }
}
