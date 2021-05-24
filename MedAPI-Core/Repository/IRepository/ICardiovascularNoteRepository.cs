using Data.Model;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface ICardiovascularNoteRepository
    {
        List<Cardiovascularnote> GetAllCardiovascularNote();
        Cardiovascularnote GetCardiovascularNoteById(long id);
        bool DeleteCardiovascularNoteById(long id);
        int SaveCardiovascularNote(Cardiovascularnote mCardiovascularNote);
        bool SaveCardiovascularSymptoms(List<CardiovascularnoteCardiovascularsymptom> CardiovascularSymptoms);        
    }
}
