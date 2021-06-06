using Repository.DTOs;

namespace Services.IServices
{
    public interface IApplicationService
    {
        Upload SaveFile(Upload mUpload);
    }
}
