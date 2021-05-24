using Data.Model;
using System.Collections.Generic;

namespace Repository.IRepository
{
    public interface ITicketRepository
    {
        Note getByTicket(string serie, string nroTicket);
        List<Note> getByPatient(long? patientId);
        Ticket SaveTicket(Ticket mTicket);
    }
}
