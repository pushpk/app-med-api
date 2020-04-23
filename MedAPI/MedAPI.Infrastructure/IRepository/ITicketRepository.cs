using MedAPI.Domain;
using System.Collections.Generic;

namespace MedAPI.Infrastructure.IRepository
{
    public interface ITicketRepository
    {
        Note getByTicket(string serie, string nroTicket);
        List<Note> getByPatient(long patientId);
    }
}
