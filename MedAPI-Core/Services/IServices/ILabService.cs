using Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
   public interface ILabService
    {
        Lab SaveLab(Lab mLab);

        LabUploadResult SaveUploadedFile(LabUploadResult mLabUploadResult);

        List<LabUploadResult> GetAllUploadsByLabAndPatient(int LabId, int patientId);

        List<LabUploadResult> GetAllUploadsByPatient(int patientId);

        LabUploadResult GetTestResultById(int id);
        Lab GetLab(long id);
        int GetActiveLabCount();
        Lab UpdateLab(Lab mLab);
    }
}
