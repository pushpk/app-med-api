using Data.Model;
using Repository.IRepository;
using System;
using System.Linq;

namespace Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly registroclinicocoreContext _context;
        public ApplicationRepository(registroclinicocoreContext _context)
        {
            this._context = _context;

        }
        public Upload Upload(Upload mUpload)
        {


            var efUpload = _context.Uploads.Where(m => m.Id == mUpload.Id).FirstOrDefault();
            if (efUpload == null)
            {

                _context.Uploads.Add(efUpload);
            }
            efUpload.CreatedBy = mUpload.CreatedBy;
            efUpload.Path = mUpload.Path;
            _context.SaveChanges();
            mUpload.Id = efUpload.Id;

            return mUpload;
        }
    }
}
