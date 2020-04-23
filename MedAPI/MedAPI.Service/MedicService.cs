using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Service
{
   public class MedicService : IMedicService
    {
        private readonly IMedicRepository medicRepository;
        public MedicService(IMedicRepository medicRepository)
        {
            this.medicRepository = medicRepository;
        }

       public List<Medic> GetAllMedic()
        {
            return medicRepository.GetAllMedic();
        }
        public Medic GetMedicById(long id)
        {
            return medicRepository.GetMedicById(id);
        }

        public bool DeleteMedicById(long id)
        {
            return medicRepository.DeleteMedicById(id);
        }
    }

}
