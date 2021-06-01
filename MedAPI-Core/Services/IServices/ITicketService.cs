using Repository.DTOs;

namespace Services.IServices
{
    public interface ITicketService
    {
         Note getByTicket(string serie, string nroTicket);
    }
}
