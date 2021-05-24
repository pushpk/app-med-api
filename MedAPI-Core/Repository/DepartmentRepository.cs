﻿using Data.Model;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public Department GetByName(string name)
        {
            using (var context = new registroclinicocoreContext())
            {
                return context.departments.Where(x => x.name == name)
                   .Select(x => new Department()
                   {
                       id = x.id,
                       name = x.name,
                       deleted = x.deleted,
                       country = new Domain.Country
                       {
                           id = x.country.id,
                           name = x.country.name
                       },
                       country_id = x.country_id,
                   }).FirstOrDefault();
            }
        }
        public List<Department> GetAllDepartment()
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new registroclinicocoreContext())
            {
                return (from c in context.departments
                        where c.deleted != true
                        select new Department()
                        {
                            deleted = c.deleted,
                            name = c.name,
                            id = c.id,
                            country = new Domain.Country
                            {
                                id = c.country.id,
                                name = c.country.name
                            },
                            country_id = c.country_id
                        }).OrderBy(x => x.name).ToList();
            }
        }
        public Department GetDepartmentById(long id)
        {
            //var bytes = BitConverter.GetBytes(true);
            using (var context = new registroclinicocoreContext())
            {
                return context.departments.Where(x => x.id == id && x.deleted != true)
                   .Select(x => new Department()
                   {
                       id = x.id,
                       name = x.name,
                       deleted = x.deleted,
                       country = new Domain.Country
                       {
                           id = x.country.id,
                           name = x.country.name
                       },
                       country_id = x.country_id,
                   }).FirstOrDefault();
            }
        }
        public bool DeleteDepartmentById(long id)
        {
            bool isSuccess = false;
            using (var context = new registroclinicocoreContext())
            {
                var efDept = context.departments.Where(m => m.id == id).FirstOrDefault();
                if (efDept != null)
                {
                    efDept.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }
        public Department SaveDepartment(Department mDepartment)
        {
            using (var context = new registroclinicocoreContext())
            {
                var efDept = context.departments.Where(m => m.id == mDepartment.id).FirstOrDefault();
                if (efDept == null)
                {
                    efDept = new DataAccess.department();
                    efDept.deleted = true; // BitConverter.GetBytes(false);
                    context.departments.Add(efDept);
                }
                efDept.name = mDepartment.name;
                efDept.country_id = mDepartment.country_id;
                context.SaveChanges();
                mDepartment.id = efDept.id;
            }
            return mDepartment;
        }
    }
}
