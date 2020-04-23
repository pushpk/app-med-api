using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Service
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }


        public Department GetByName(string name)
        {
            return departmentRepository.GetByName(name);
        }

        public List<Department> GetAllDepartment()
        {
            return departmentRepository.GetAllDepartment();
        }

        public Department GetDepartmentById(long id)
        {
            return departmentRepository.GetDepartmentById(id);
        }

        public bool DeleteDepartmentById(long id)
        {
            return departmentRepository.DeleteDepartmentById(id);
        }
        public Department SaveDepartment(Department mDepartment)
        {
            return departmentRepository.SaveDepartment(mDepartment);
        }
    }
}
