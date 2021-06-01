using Repository;
using Repository.DTOs;
using Repository.IRepository;
using Services.IServices;

using System.Collections.Generic;

namespace Services
{
    public class LabService : ILabService
    {
        private readonly ILabRepository labRepository;
        private readonly IUserRepository userRepository;
        public LabService(ILabRepository labRepository, IUserRepository userRepository)
        {
            this.labRepository = labRepository;
            this.userRepository = userRepository;
        }

        public List<LabUploadResult> GetAllUploadsByLabAndPatient(int LabId, int patientId)
        {
            return labRepository.GetAllUploadsByLabAndPatient(LabId, patientId);
        }

        public List<LabUploadResult> GetAllUploadsByPatient(int patientId)
        {
            return labRepository.GetAllUploadsByPatient(patientId);
        }

        public LabUploadResult GetTestResultById(int id)
        {
            return labRepository.GetTestResultById(id);
        }

        public Lab SaveLab(Lab mLab)
        {

            if (mLab.user.id == 0)
            {
                mLab.user.passwordHash = Services.Helpers.HashPasswordHelper.HashPassword(mLab.user.passwordHash);
            }
            mLab.user = userRepository.SaveUser(mLab.user);

            if (mLab.user.id > 0)
            {
                mLab.userId = mLab.user.id;
                labRepository.SaveLab(mLab);
            }
            return mLab;
        }

        public LabUploadResult SaveUploadedFile(LabUploadResult mLabUploadResult)
        {
            labRepository.SaveUploadedFile(mLabUploadResult);
            return mLabUploadResult;
        }

        public Lab GetLab(long id)
        {
            return labRepository.GetLab(id);
        }

        public int GetActiveLabCount()
        {
            return labRepository.GetActiveLabCount();
        }

        public Lab UpdateLab(Lab mLab)
        {
            return labRepository.UpdateLab(mLab);
        }
    }

}
