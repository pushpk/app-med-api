using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IRepository
{
   public interface IMedicineRepository
    {
        List<Medicine> SearchByName(string name);
        List<Medicine> GetAllMedicine();
        Medicine GetMedicineById(long id);
        bool DeleteMedicineById(long id);
        int SaveMedicine(Medicine mMedicine);
    }
}
