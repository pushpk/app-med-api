using Repository.DTOs;
using Repository.IRepository;
using Services.IServices;

namespace Services
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
        public Triage SaveTriage(Triage triage)
        {
            return triageRepository.SaveTriage(triage);
        }
    }
}
