using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Service
{
    public class CardiovascularNoteService : ICardiovascularNoteService
    {
        private readonly ICardiovascularNoteRepository cardiovascularNoteRepository;

        public CardiovascularNoteService(ICardiovascularNoteRepository cardiovascularNoteRepository)
        {
            this.cardiovascularNoteRepository = cardiovascularNoteRepository;
        }

        public bool DeleteCardiovascularNoteById(long id)
        {
            return cardiovascularNoteRepository.DeleteCardiovascularNoteById(id);
        }

        public List<CardiovascularNote> GetAllCardiovascularNote()
        {
            return cardiovascularNoteRepository.GetAllCardiovascularNote();
        }

        public CardiovascularNote GetCardiovascularNoteById(long id)
        {
            return cardiovascularNoteRepository.GetCardiovascularNoteById(id);
        }

        public int SaveCardiovascularNote(CardiovascularNote mCardiovascularNote)
        {
            return cardiovascularNoteRepository.SaveCardiovascularNote(mCardiovascularNote);
        }
    }
}
