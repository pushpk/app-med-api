using System.Collections.Generic;
using MedAPI.Domain;

namespace MedAPI.Infrastructure.IRepository
{
    public interface IDistrictRepository
    {
        List<District> GetAllDistrict();
        District SaveDistrict(District mDistrict);
        District GetDistrictById(long id);
        bool DeleteDistrictById(long id);
    }
}
