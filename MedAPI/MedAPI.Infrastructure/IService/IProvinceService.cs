using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IService
{
    public interface IProvinceService
    {
        List<Province> GetAllProvince();
         List<Province> Search(string name, int id);
        Province SaveProvince(Province mProvince);
        Province GetProvinceById(long id);
        bool DeleteProvinceById(long id);
    }
}
