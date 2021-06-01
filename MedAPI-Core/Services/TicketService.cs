using Repository.DTOs;
using Repository.IRepository;
using Services.IServices;
using System.Collections.Generic;

namespace Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        public Note getByTicket(string serie, string nroTicket)
        {
            var note = ticketRepository.getByTicket(serie, nroTicket);
            if (note != null)
            {
                List<Note> mNotes = ticketRepository.getByPatient(note.patientId);

                note.noteList = mNotes;
            }
            return note;
        }
    }
}
