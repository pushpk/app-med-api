using Data.Model;
using System.Collections.Generic;

namespace Repository.IRepository
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
