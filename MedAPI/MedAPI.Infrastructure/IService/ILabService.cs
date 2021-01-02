using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IService
{
   public interface ILabService
    {
        Lab SaveLab(Domain.Lab mLab);

        LabUploadResult SaveUploadedFile(Domain.LabUploadResult mLabUploadResult);

        List<LabUploadResult> GetAllUploadsByLabAndPatient(int LabId, int patientId);

        List<LabUploadResult> GetAllUploadsByPatient(int patientId);

        LabUploadResult GetTestResultById(int id);
        Lab GetLab(long id);
        int GetActiveLabCount();
        Lab UpdateLab(Lab mLab);
    }
}
