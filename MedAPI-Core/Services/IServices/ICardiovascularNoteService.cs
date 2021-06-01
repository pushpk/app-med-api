using Repository.DTOs;
using System.Collections.Generic;

namespace Services.IServices
{
    public interface ICardiovascularNoteService
    {
        List<CardiovascularNote> GetAllCardiovascularNote();
        CardiovascularNote GetCardiovascularNoteById(long id);
        bool DeleteCardiovascularNoteById(long id);
        int SaveCardiovascularNote(CardiovascularNote mCardiovascularNote);
        CardiovascularResource GetResources();
        bool SaveCardiovascularSymptoms(List<CardiovascularSymptoms> mCardiovascularSymptom);
    }
}
