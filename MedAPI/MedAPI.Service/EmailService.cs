using MedAPI.Infrastructure;
using MedAPI.Infrastructure.IService;
using System.Collections.Generic;

namespace MedAPI.Service
{
    public class EmailService: IEmailService
    {

        public string SendEmail()
        {
            string subject = "Amazon SES test (SMTP interface accessed using Java)";
            string body = "This email was sent through the Amazon SES SMTP interface by using Java.";

            List<string> to = new List<string>();
            to.Add("aldo.roman.nurena@gmail.com");

            SendMailHelper sendMailHelper = new SendMailHelper();
            sendMailHelper.Send(subject, body, to);
            return "Email sent.";
        }
    }
}
