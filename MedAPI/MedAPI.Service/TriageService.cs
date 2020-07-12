using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;

namespace MedAPI.Service
{
    public class TriageService : ITriageService
    {
        private readonly ITriageRepository triageRepository;

        public TriageService(ITriageRepository triageRepository)
        {
            this.triageRepository = triageRepository;
        }
        public Triage GetLatest(Patient mPatient)
        {
            return triageRepository.GetLatest(mPatient.id);
        }
    }
}
