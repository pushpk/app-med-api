﻿using Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IEstablishmentRepository
    {
        List<Establishment> GetAllEstablishment();
        Establishment SaveEstablishment(Establishment mEstablishment);
        Establishment GetEstablishmentById(long id);
        bool DeleteEstablishmentById(long id);
    }
}
