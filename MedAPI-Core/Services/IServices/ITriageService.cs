using Repository.DTOs;

namespace Services.IServices
{
    public interface ITriageService
    {
        Triage GetLatest(Patient mPatient);
        Triage SaveTriage(Triage triage);
    }
}
