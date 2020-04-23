using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IService
{
   public interface IEstablishmentService
    {
        List<Establishment> GetAllEstablishment();
        Establishment SaveEstablishment(Establishment mEstablishment);
        Establishment GetEstablishmentById(long id);
        bool DeleteEstablishmentById(long id);
    }
}
