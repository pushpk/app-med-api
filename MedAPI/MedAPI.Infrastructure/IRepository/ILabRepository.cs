﻿using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Repository
{
    public interface ILabRepository
    {
        long SaveLab(Lab mMedic);

        long SaveUploadedFile(LabUploadResult labResult);

        List<LabUploadResult> GetAllUploadsByLabAndPatient(int LabId, int patientId);

        List<LabUploadResult> GetAllUploadsByPatient(int patientId);

        LabUploadResult GetTestResultById(int id);

        Lab GetLab(long id);

        Lab UpdateLab(Lab mLab);

        int GetActiveLabCount();

    }
}