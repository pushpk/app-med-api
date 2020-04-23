using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface IMedicineService
    {
        List<Medicine> SearchByName(string name);
        List<Medicine> GetAllMedicine();
        Medicine GetMedicineById(long id);
        int SaveMedicine(Medicine mMedicine);
        bool DeleteMedicineById(long id);
    }
}
