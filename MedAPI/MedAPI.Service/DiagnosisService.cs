using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Service
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IDiagnosisRepository diagnosisRepository;

        public DiagnosisService(IDiagnosisRepository diagnosisRepository)
        {
            this.diagnosisRepository = diagnosisRepository;
        }

        public bool DeleteDiagnosisById(long id)
        {
            return diagnosisRepository.DeleteDiagnosisById(id);
        }

        public List<Diagnosis> GetAllDiagnosis()
        {
            return diagnosisRepository.GetAllDiagnosis();
        }

        public Diagnosis GetDiagnosisById(long id)
        {
            return diagnosisRepository.GetDiagnosisById(id);
        }

        public int SaveDiagnosis(Diagnosis mDiagnosis)
        {
            if (mDiagnosis.chapter != null)
            {
                int chapterID = diagnosisRepository.SaveChapter(mDiagnosis.chapter);
            }
            return diagnosisRepository.SaveDiagnosis(mDiagnosis);
        }

        public List<Diagnosis> SearchByNameOrCode(string name)
        {
            List<Diagnosis> mDiagnosisList = new List<Diagnosis>();


            if (!string.IsNullOrEmpty(name))
            {
                mDiagnosisList = diagnosisRepository.SearchByNameOrCode(name);
            }
            //if (!string.IsNullOrEmpty(name))
            //{
            //    List<Diagnosis> diagnosisName = diagnosisRepository.SearchByName(name);
            //    mDiagnosisList.Concat(diagnosisName).ToList();
            //}
            return mDiagnosisList;
        }


    }
}
