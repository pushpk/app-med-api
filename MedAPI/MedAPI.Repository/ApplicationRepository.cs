using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Linq;

namespace MedAPI.Repository
{
    public class ApplicationRepository: IApplicationRepository
    {
        public Upload Upload(Upload mUpload)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efUpload = context.uploads.Where(m => m.id == mUpload.id).FirstOrDefault();
                if (efUpload == null)
                {
                    efUpload = new DataAccess.upload();
                    efUpload.createdDate = DateTime.UtcNow;
                    efUpload.deleted = false; /*BitConverter.GetBytes()*/
                     context.uploads.Add(efUpload);
                }
                efUpload.createdBy = mUpload.createdBy;
                efUpload.path = mUpload.path;
                context.SaveChanges();
                mUpload.id = efUpload.id;
            }
            return mUpload;
        }
    }
}
