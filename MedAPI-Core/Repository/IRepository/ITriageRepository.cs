using Data.Model;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface ITriageRepository
    {
        Triage GetLatest(long id);
        Triage SaveTriage(Triage triage);
        List<Speciality> getSpecialities();
    }
}
