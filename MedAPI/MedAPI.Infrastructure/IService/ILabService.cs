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

        List<LabUploadResult> GetAllUploadsByLab(int LabId);

        List<LabUploadResult> GetAllUploadsByPatient(int patientId);

        LabUploadResult GetTestResultById(int id);
    }
}
