using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IRepository
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
