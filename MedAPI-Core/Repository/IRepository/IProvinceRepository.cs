﻿using Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IProvinceRepository
    {
        List<Province> GetAllProvince();
        List<Province> GetAllProvinceByName(string name);
        List<Province> GetAllProvinceByDeparmentId(long departmentId);
        Province SaveProvince(Province mProvince);
        Province GetProvinceById(long id);
        bool DeleteProvinceById(long id);
    }
}
