using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IRepository
{
    public interface ISpecialtyRepository
    {

        List<MedicSpecialties> SearchByName(string name);
    }
}