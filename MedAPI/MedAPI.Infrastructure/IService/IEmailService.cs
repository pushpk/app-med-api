using System.Threading.Tasks;
using static MedAPI.Infrastructure.EmailHelper;

namespace MedAPI.Infrastructure.IService
{
    public interface IEmailService
    {
        //string SendEmail();
        Task SendEmailAsync(string email, string subject, string body, string link=null, string name = null, string dni = null);
        string GetEmailBody(EmailPurpose purpose, string link = null);
    }
}
