using Repository.DTOs;
using Repository.IRepository;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public class DistrictService: IDistrictService
    {
        private readonly IDistrictRepository districtRepository;
        public DistrictService(IDistrictRepository districtRepository)
        {
            this.districtRepository = districtRepository;
        }

        public List<District> GetAllDistrict()
        {
            return districtRepository.GetAllDistrict();
        }
        public District SaveDistrict(District mDistrict)
        {
            return districtRepository.SaveDistrict(mDistrict);
        }
        public District GetDistrictById(long id)
        {
            return districtRepository.GetDistrictById(id);
        }
        public bool DeleteDistrictById(long id)
        {
            return districtRepository.DeleteDistrictById(id);
        }

    }
}
