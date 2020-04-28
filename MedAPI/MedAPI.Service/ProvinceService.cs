using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Service
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            this.provinceRepository = provinceRepository;
        }

        public List<Province> GetAllProvince()
        {
            return provinceRepository.GetAllProvince();
        }

        public List<Province> Search(string name,int id)
        {
            List<Province> mProvinceList = new List<Province>();
            if (!string.IsNullOrEmpty(name))
            {
                mProvinceList = provinceRepository.GetAllProvinceByName(name);
            }
            if (id!=null && id>0)
            {
                List<Province> mProvinceList2 = provinceRepository.GetAllProvinceByDeparmentId(id);
                mProvinceList.AddRange(mProvinceList2);
            }
            return mProvinceList;
        }

        public Province SaveProvince(Province mProvince)
        {
            return provinceRepository.SaveProvince(mProvince);
        }

        public Province GetProvinceById(long id)
        {
            return provinceRepository.GetProvinceById(id);
        }

        public bool DeleteProvinceById(long id)
        {
            return provinceRepository.DeleteProvinceById(id);
        }

    }
}
