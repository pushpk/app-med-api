using MedAPI.Domain;

namespace MedAPI.Infrastructure.IService
{
    public interface ITicketService
    {
         Note getByTicket(string serie, string nroTicket);
    }
}
