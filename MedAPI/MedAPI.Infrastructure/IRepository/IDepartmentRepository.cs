using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IRepository
{
    public interface IDepartmentRepository
    {
        Department GetByName(string name);
        List<Department> GetAllDepartment();
        Department GetDepartmentById(long id);
        bool DeleteDepartmentById(long id);
        Department SaveDepartment(Department mDepartment);
    }
}
