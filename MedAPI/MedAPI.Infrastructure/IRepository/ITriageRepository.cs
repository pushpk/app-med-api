using MedAPI.Domain;

namespace MedAPI.Infrastructure.IRepository
{
    public interface ITriageRepository
    {
        Triage GetLatest(long id);
    }
}
