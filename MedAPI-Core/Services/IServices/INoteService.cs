using Repository.DTOs;
using System.Collections.Generic;

namespace Services.IServices
{
    public interface INoteService
    {
        List<Note> GetAllNoteByPatient(int id);
        List<Note> GetAllNote();
        Note GetNoteById(long id);
        bool DeleteNoteById(long id);
        Note SaveNote(Note mNote);
        Triage TriageSave(Triage triage);
        NoteResources GetResources();

        bool SaveDiagnosisList(List<NoteDiagnosi> mDiagnosis);
        bool SaveExamsList(List<NoteExam> mExams);
        bool SaveMedicationsList(List<NoteMedicine> mMedications);
        bool SaveReferralsList(List<NoteReferral> mReferrals);
        bool CloseAttention(long id);
        bool saveSignature(int noteId, bool isSignDraw, string signText, byte[] signImageData);
        byte[] GetNoteSignatureIfDraw(int noteId);
    }
}
