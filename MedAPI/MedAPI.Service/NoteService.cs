using System.Collections.Generic;
using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;

namespace MedAPI.Service
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepository;
        private readonly ITriageRepository triageRepository;
        private readonly ITicketRepository ticketRepository;
        public NoteService(INoteRepository noteRepository, ITriageRepository triageRepository, ITicketRepository ticketRepository)
        {
            this.noteRepository = noteRepository;
            this.ticketRepository = ticketRepository;
            this.triageRepository = triageRepository;
        }

        public bool DeleteNoteById(long id)
        {
            return noteRepository.DeleteNoteById(id);
        }

        public List<Note> GetAllNote()
        {
            return noteRepository.GetAllNote();
        }

        public Note GetNoteById(long id)
        {
            return noteRepository.GetNoteById(id);
        }

        public Note SaveNote(Note mNote)
        {
            var ticket = ticketRepository.SaveTicket(mNote.Ticket);
            if (ticket.id > 0)
            {
                mNote.TicketId = ticket.id;
                mNote.Triage.TicketId= ticket.id;
            }
            var triage = triageRepository.SaveTriage(mNote.Triage);
            if (triage.Id > 0)
                mNote.TriageId = triage.Id;

            return noteRepository.SaveNote(mNote);
        }
        public Triage TriageSave(Triage triage)
        {
            return triageRepository.SaveTriage(triage);
        }
    }
}
