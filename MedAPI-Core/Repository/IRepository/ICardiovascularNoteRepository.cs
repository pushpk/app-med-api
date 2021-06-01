using Repository.DTOs;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface ICardiovascularNoteRepository
    {
        List<CardiovascularNote> GetAllCardiovascularNote();
        CardiovascularNote GetCardiovascularNoteById(long id);
        bool DeleteCardiovascularNoteById(long id);
        int SaveCardiovascularNote(CardiovascularNote mCardiovascularNote);
        bool SaveCardiovascularSymptoms(List<CardiovascularSymptoms> CardiovascularSymptoms);        
    }
}
