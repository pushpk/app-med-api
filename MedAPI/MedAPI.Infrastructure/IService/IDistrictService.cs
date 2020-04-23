using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface IDistrictService
    {
        List<District> GetAllDistrict();
        District SaveDistrict(District mDistrict);
        District GetDistrictById(long id);
        bool DeleteDistrictById(long id);
    }
}
