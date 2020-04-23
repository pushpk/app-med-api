using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface IDepartmentService
    {
        Department GetByName(string name);
        List<Department> GetAllDepartment();
        Department GetDepartmentById(long id);
        bool DeleteDepartmentById(long id);
        Department SaveDepartment(Department mDepartment);
    }
}
