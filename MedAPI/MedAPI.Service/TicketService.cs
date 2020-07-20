using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System.Collections.Generic;

namespace MedAPI.Service
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
                List<Domain.Note> mNotes = ticketRepository.getByPatient(note.patientId);

                note.noteList = mNotes;
            }
            return note;
        }
    }
}
