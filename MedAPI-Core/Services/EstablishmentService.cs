using Repository.DTOs;
using Repository.IRepository;
using Services.IServices;
using System.Collections.Generic;

namespace Services
{
    public class EstablishmentService: IEstablishmentService
    {
        private readonly IEstablishmentRepository establishmentRepository;
        public EstablishmentService(IEstablishmentRepository establishmentRepository)
        {
            this.establishmentRepository = establishmentRepository;
        }
        public List<Establishment> GetAllEstablishment()
        {
            return establishmentRepository.GetAllEstablishment();
        }
        public Establishment SaveEstablishment(Establishment mEstablishment)
        {
            return establishmentRepository.SaveEstablishment(mEstablishment);
        }
        public Establishment GetEstablishmentById(long id)
        {
            return establishmentRepository.GetEstablishmentById(id);
        }
      
        public bool DeleteEstablishmentById(long id)
        {
            return establishmentRepository.DeleteEstablishmentById(id);
        }
    }
}
