using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IService
{
    public interface ICardiovascularNoteService
    {
        List<CardiovascularNote> GetAllCardiovascularNote();
        CardiovascularNote GetCardiovascularNoteById(long id);
        bool DeleteCardiovascularNoteById(long id);
        int SaveCardiovascularNote(CardiovascularNote mCardiovascularNote);
        CardiovascularResource GetResources();
    }
}
