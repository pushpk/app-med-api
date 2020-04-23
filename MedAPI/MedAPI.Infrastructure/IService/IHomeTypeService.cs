using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IService
{
   public interface IHomeTypeService
    {
        List<string> GetAllHomeType();
    }
}
