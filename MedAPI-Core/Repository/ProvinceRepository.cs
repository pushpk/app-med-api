﻿using Data.DataModels;
using Repository.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly registroclinicocoreContext context;
        public ProvinceRepository(registroclinicocoreContext context)
        {
            this.context = context;

        }
        public List<Province> GetAllProvinceByName(string name)
        {
           
                return (from c in context.provinces
                        where c.name.ToLower().Contains(name.ToLower())
                        select new Province()
                        {
                            deleted = c.deleted,
                            name = c.name,
                            id = c.id,
                            departmentId = c.department_id,
                        }).ToList();
            
        }
        public List<Province> GetAllProvinceByDeparmentId(long departmentId)
        {
          
                return (from c in context.provinces
                        where c.department_id == departmentId && c.deleted != true
                        select new Province()
                        {
                            deleted = c.deleted,
                            name = c.name,
                            id = c.id,
                            departmentId = c.department_id,
                        }).OrderBy(x => x.name).ToList();
            
        }

        public List<Province> GetAllProvince()
        {
            //var bytes = BitConverter.GetBytes(true);
          
                return (from c in context.provinces
                        where c.deleted != true
                        select new Province()
                        {
                            deleted = c.deleted,
                            name = c.name,
                            id = c.id,
                            departmentId = c.department_id,
                        }).OrderBy(x => x.name).ToList();
            
        }

        public Province SaveProvince(Province mProvince)
        {
            
                var efProvince = context.provinces.Where(m => m.id == mProvince.id && m.deleted != true).FirstOrDefault();
                if (efProvince == null)
                {
                    efProvince = new province();
                    efProvince.deleted = false;// BitConverter.GetBytes(false);
                    context.provinces.Add(efProvince);
                }
                efProvince.name = mProvince.name;
                efProvince.department_id = mProvince.departmentId;
                context.SaveChanges();
                mProvince.id = efProvince.id;
            
            return mProvince;
        }

        public Province GetProvinceById(long id)
        {
           
                return context.provinces.Where(x => x.id == id && x.deleted != true)
                   .Select(x => new Province()
                   {
                       id = x.id,
                       name = x.name,
                       deleted = x.deleted,
                       departmentId = x.department_id
                   }).FirstOrDefault();
            
        }
        public bool DeleteProvinceById(long id)
        {
            bool isSuccess = false;
           
                var efprovinces = context.provinces.Where(m => m.id == id).FirstOrDefault();
                if (efprovinces != null)
                {
                    efprovinces.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            
        }
    }
}
