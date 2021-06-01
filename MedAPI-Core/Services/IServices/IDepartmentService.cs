using Repository.DTOs;
using System.Collections.Generic;

namespace Services.IServices
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
