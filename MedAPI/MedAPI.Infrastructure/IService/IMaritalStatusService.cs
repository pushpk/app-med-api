using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface IMaritalStatusService
    {
        List<string> GetAllMaritalStatus();
    }
}
