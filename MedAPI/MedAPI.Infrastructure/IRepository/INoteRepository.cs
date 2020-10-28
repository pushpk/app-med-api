using MedAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IRepository
{
    public interface INoteRepository
    {
        List<Note> GetAllNoteByPatient(int id);
        List<Note> GetAllNote();
        bool DeleteNoteById(long id);
        Note GetNoteById(long id);
        Note SaveNote(Note mNote);
        bool SaveDiagnosisList(List<NoteDiagnosi> mDiagnosis);
        bool SaveExamsList(List<NoteExam> mExams);
        bool SaveMedicationsList(List<NoteMedicine> mMedications);
        bool SaveReferralsList(List<NoteReferral> mReferrals);
        bool CloseAttention(long id);
    }
}
