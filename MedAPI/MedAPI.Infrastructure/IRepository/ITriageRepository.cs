using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IRepository
{
    public interface ITriageRepository
    {
        Triage GetLatest(long id);
        Triage SaveTriage(Triage triage);
        List<Speciality> getSpecialities();
    }
}
