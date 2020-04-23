using MedAPI.Domain;

namespace MedAPI.Infrastructure.IService
{
    public interface IApplicationService
    {
        Upload SaveFile(Upload mUpload);
    }
}
