using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using MedAPI.Repository;
using System.Collections.Generic;

namespace MedAPI.Service
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

        public Lab SaveLab(Domain.Lab mLab)
        {

            if (mLab.user.id == 0)
            {
                mLab.user.passwordHash = Infrastructure.HashPasswordHelper.HashPassword(mLab.user.passwordHash);
            }
            mLab.user = userRepository.SaveUser(mLab.user);

            if (mLab.user.id > 0)
            {
                mLab.userId = mLab.user.id;
                labRepository.SaveLab(mLab);
            }
            return mLab;
        }

        public LabUploadResult SaveUploadedFile(Domain.LabUploadResult mLabUploadResult)
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
