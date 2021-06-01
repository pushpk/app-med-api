using Data.DataModels;
using Repository.DTOs;
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


            var efUpload = _context.uploads.Where(m => m.id == mUpload.id).FirstOrDefault();
            if (efUpload == null)
            {

                _context.uploads.Add(efUpload);
            }
            efUpload.createdBy = mUpload.createdBy;
            efUpload.path = mUpload.path;
            _context.SaveChanges();
            mUpload.id = efUpload.id;

            return mUpload;
        }
    }
}
