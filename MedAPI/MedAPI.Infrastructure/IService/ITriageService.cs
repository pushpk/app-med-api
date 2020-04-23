using MedAPI.Domain;

namespace MedAPI.Infrastructure.IService
{
    public interface ITriageService
    {
        Triage GetLatest(Patient mPatient);
    }
}
