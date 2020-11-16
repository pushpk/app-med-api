using System.Threading.Tasks;

namespace MedAPI.Infrastructure.IService
{
    public interface IEmailService
    {
        //string SendEmail();
        Task SendEmailAsync(string email, string subject, string body);
    }
}
