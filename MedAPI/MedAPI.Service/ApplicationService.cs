using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System.IO;
using System.Web;

namespace MedAPI.Service
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository applicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public Upload SaveFile(Upload mUpload)
        {
           
            string filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/public/assets"),mUpload.Filename);
            string absultepath = "/public/assets/" + mUpload.Filename;
            if (mUpload.FileByte != null)
            {
                File.WriteAllBytes(filePath, mUpload.FileByte);
                mUpload.Path = absultepath;
                applicationRepository.Upload(mUpload);
            }
            return mUpload;
        }
    }
}
