using MedAPI.Domain;

namespace MedAPI.Infrastructure.IRepository
{
    public interface IApplicationRepository
    {
        Upload Upload(Upload mUpload);
    }
}
