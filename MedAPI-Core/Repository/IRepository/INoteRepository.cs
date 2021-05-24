using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface INoteRepository
    {
        List<Note> GetAllNoteByPatient(int id);
        List<Note> GetAllNote();
        bool DeleteNoteById(long id);
        Note GetNoteById(long id);
        Note SaveNote(Note mNote);
        bool SaveDiagnosisList(List<Notediagnosis> mDiagnosis);
        bool SaveExamsList(List<Noteexam> mExams);
        bool SaveMedicationsList(List<Notemedicine> mMedications);
        bool SaveReferralsList(List<Notereferral> mReferrals);
        bool CloseAttention(long id);
        bool saveSignature(int noteId, bool isSignDraw, string signText, byte[] signImageData);
        byte[] GetNoteSignatureIfDraw(int noteId);
    }
}
