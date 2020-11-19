using MedAPI.Domain;
using MedAPI.Infrastructure;
using MedAPI.Infrastructure.IService;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;



namespace MedAPI.Service
{
    public class EmailService : IEmailService
    {

        //public string SendEmail()
        //{
        //    string subject = "Amazon SES test (SMTP interface accessed using Java)";
        //    string body = "This email was sent through the Amazon SES SMTP interface by using Java.";

        //    List<string> to = new List<string>();
        //    to.Add("aldo.roman.nurena@gmail.com");

        //    SendMailHelper sendMailHelper = new SendMailHelper();
        //    sendMailHelper.Send(subject, body, to);
        //    return "Email sent.";
        //}
        //private readonly IOptions<SendgridSettings> _settings;

        //public EmailService(IOptions<SendgridSettings> settings)
        //{
        //    _settings = settings;
        //}

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            //SmtpServer.Host = ConfigurationManager.AppSettings.Get("HOST");
            //mail.From = new MailAddress(ConfigurationManager.AppSettings.Get("FROM"));

            //var key = _settings.Value.ApiKey;
            var key = ConfigurationManager.AppSettings.Get("EmailApiKey");
            var user = ConfigurationManager.AppSettings.Get("EmailUser");
            var client = new SendGridClient(key);
            var msg = new SendGridMessage
            {
                From = new EmailAddress("admin@solidaritymedical.net", user),
                Subject = subject,
                PlainTextContent = body,
                HtmlContent = body
            };
            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);

            await client.SendEmailAsync(msg);
        }
    }
}
