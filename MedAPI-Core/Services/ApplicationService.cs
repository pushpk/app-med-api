using Microsoft.AspNetCore.Http;
using Repository.DTOs;
using Repository.IRepository;
using Services.IServices;
using System.IO;
using System.Web;

namespace Services
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
            throw new System.NotImplementedException();
        }

        //public Upload SaveFile(Upload mUpload)
        //{

        //    //string filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/public/assets"), mUpload.filename);
        //    //string absultepath = "/public/assets/" + mUpload.filename;
        //    //if (mUpload.fileByte != null)
        //    //{
        //    //    File.WriteAllBytes(filePath, mUpload.fileByte);
        //    //    mUpload.path = absultepath;
        //    //    applicationRepository.Upload(mUpload);
        //    //}
        //    //return mUpload;

        //    throw new Ec; 
        //}
    }
}
