using Repository.DTOs;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface ISpecialtyRepository
    {

        List<Speciality> SearchByName(string name);
    }
}