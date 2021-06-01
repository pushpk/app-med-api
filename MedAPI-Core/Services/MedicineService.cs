using System.Collections.Generic;
using Repository.DTOs;
using Repository.IRepository;
using Services.IServices;

namespace Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }

        public bool DeleteMedicineById(long id)
        {
            return medicineRepository.DeleteMedicineById(id);
        }

        public List<Medicine> GetAllMedicine()
        {
            return medicineRepository.GetAllMedicine();
        }

        public Medicine GetMedicineById(long id)
        {
            return medicineRepository.GetMedicineById(id);
        }

        public int SaveMedicine(Medicine mMedicine)
        {
            return medicineRepository.SaveMedicine(mMedicine);
        }

        public List<Medicine> SearchByName(string name)
        {
            List<Medicine> medicines = new List<Medicine>();
            if (!string.IsNullOrEmpty(name))
            {
                medicines = medicineRepository.SearchByName(name);
            }
            return medicines;
        }
    }
}
