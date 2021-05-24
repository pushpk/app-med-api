using Data.Model;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CardiovascularNoteRepository : ICardiovascularNoteRepository
    {
        public bool DeleteCardiovascularNoteById(long id)
        {
            bool isSuccess = false;
            using (var context = new registroclinicocoreContext())
            {
                var efCardiovascularnotes = context.Cardiovascularnotes.Where(m => m.Id == id).FirstOrDefault();
                if (efCardiovascularnotes != null)
                {
                    context.Entry(efCardiovascularnotes).State = EntityState.Deleted;
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<Cardiovascularnote> GetAllCardiovascularNote()
        {
            using (var context = new registroclinicocoreContext())
            {
                return context.Cardiovascularnotes.ToList();
            }
        }

        public Cardiovascularnote GetCardiovascularNoteById(long id)
        {
            using (var context = new registroclinicocoreContext())
            {
                return context.Cardiovascularnotes.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public int SaveCardiovascularNote(Cardiovascularnote mCardiovascularNote)
        {
            using (var context = new registroclinicocoreContext())
            {
                var efCardiovascularNote = context.Cardiovascularnotes.Where(x => x.NoteId == mCardiovascularNote.NoteId).FirstOrDefault();
                if (efCardiovascularNote == null)
                {
                    context.Cardiovascularnotes.Add(efCardiovascularNote);
                }
                else
                {
                    context.Update(efCardiovascularNote);
                    
                }
               
                context.SaveChanges();
                mCardiovascularNote.Id = efCardiovascularNote.Id;
                return Convert.ToInt32(efCardiovascularNote.Id);
            }
        }

        public bool SaveCardiovascularSymptoms(List<CardiovascularnoteCardiovascularsymptom> CardiovascularSymptoms)
        {
            using (var context = new registroclinicocoreContext())
            {
                try
                {
                    foreach (var cardiovascularSymptom in CardiovascularSymptoms)
                    {
                        var efCardiovascularSymptom = context.CardiovascularnoteCardiovascularsymptoms.Where(x => x.Id == cardiovascularSymptom.Id 
                        && x.CardiovascularNoteId== cardiovascularSymptom.CardiovascularNoteId).FirstOrDefault();
                        
                        if (efCardiovascularSymptom == null)
                        {
                            context.CardiovascularnoteCardiovascularsymptoms.Add(efCardiovascularSymptom);

                        }
                        else
                        {
                            context.Update(efCardiovascularSymptom);
                        }

                       
                        context.SaveChanges();
                    }

                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
