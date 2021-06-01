using Data.DataModels;

using Repository.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly registroclinicocoreContext context;
        public DepartmentRepository(registroclinicocoreContext context)
        {
            this.context = context;

        }

        public Department GetByName(string name)
        {
           
                return context.departments.Where(x => x.name == name)
                   .Select(x => new Department()
                   {
                       id = x.id,
                       name = x.name,
                       deleted = x.deleted,
                       country = new Country
                       {
                           id = x.country.id,
                           name = x.country.name
                       },
                       country_id = x.country_id,
                   }).FirstOrDefault();
            
        }
        public List<Department> GetAllDepartment()
        {
            //var bytes = BitConverter.GetBytes(true);
            
                return (from c in context.departments
                        where c.deleted != true
                        select new Department()
                        {
                            deleted = c.deleted,
                            name = c.name,
                            id = c.id,
                            country = new Country
                            {
                                id = c.country.id,
                                name = c.country.name
                            },
                            country_id = c.country_id
                        }).OrderBy(x => x.name).ToList();
            
        }
        public Department GetDepartmentById(long id)
        {
            //var bytes = BitConverter.GetBytes(true);
          
                return context.departments.Where(x => x.id == id && x.deleted != true)
                   .Select(x => new Department()
                   {
                       id = x.id,
                       name = x.name,
                       deleted = x.deleted,
                       country = new Country
                       {
                           id = x.country.id,
                           name = x.country.name
                       },
                       country_id = x.country_id,
                   }).FirstOrDefault();
            
        }
        public bool DeleteDepartmentById(long id)
        {
            bool isSuccess = false;
           
                var efDept = context.departments.Where(m => m.id == id).FirstOrDefault();
                if (efDept != null)
                {
                    efDept.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            
        }
        public Department SaveDepartment(Department mDepartment)
        {
           
                var efDept = context.departments.Where(m => m.id == mDepartment.id).FirstOrDefault();
                if (efDept == null)
                {
                    efDept = new department();
                    efDept.deleted = true; // BitConverter.GetBytes(false);
                    context.departments.Add(efDept);
                }
                efDept.name = mDepartment.name;
                efDept.country_id = mDepartment.country_id;
                context.SaveChanges();
                mDepartment.id = efDept.id;
            
            return mDepartment;
        }
    }
}
