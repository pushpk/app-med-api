using Repository.DTOs;
using System.Collections.Generic;

namespace Services.IServices
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
