using MedAPI.Domain;
using MedAPI.Infrastructure;
using MedAPI.Infrastructure.IService;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;
using static MedAPI.Infrastructure.EmailHelper;
using System.Web;

namespace MedAPI.Service
{
    public class EmailService : IEmailService
    {
        public string GetEmailBody(EmailPurpose purpose, string link = null)
        {
            switch (purpose)
            {
                case EmailPurpose.EmailVerification:
                    //return $"Estimado cliente, <br /><br />Gracias por registrase con Solidarity Medical! Necesitamos verificar su cuenta de correo electrónico antes de continuar con la apertura de su cuenta. Por favor <a href='{link}' >haga click aquí </a>para verificar su email. <br/><br/> Si usted no ha intentado registrarse con nosotros, por favor contáctenos a admin@solidaritymedical.net.<br /><br /> Muchas gracias! Esperamos que disfrute de nuestros servicios, <br /><br />Solidarity Medical <br /><br />";
                    return "d-2bb1c1be21394a0abe9ec5b519d5f3ff";
                 case EmailPurpose.ForgotPassword:
                    //return $"Estimado cliente,<br /><br />Hemos recibido una solicitud para restablecer su contraseña. Si usted mandó esta solicitud, por favor <a href='{link}' >haga click aquí </a> para escoger una nueva contraseña. Si no ha sido usted, por favor contáctenos a admin@solidaritymedical.net.<br /><br />Muchas gracias,<br /><br />Solidarity Medical <br /><br />";
                    return "d-e9fd207f124a4f4b87f6550bcb363215";
                case EmailPurpose.ApproveAccount:
                    //return $"Estimado cliente,<br /><br />Felicitaciones, su cuenta ha sido aprobada! Ahora podrá disfrutar de nuestros servicios.<br /><br />Muchas gracias,<br /><br />Solidarity Medical.<br /><br />";
                    return "d-8d858c1068234f13937c8e66b62990c7";
                case EmailPurpose.DenyAccount:
                    //return $"Estimado cliente,<br /><br />Lamentamos avisarle que su aplicación no ha sido aceptada por nuestros administradores. Si desea refutar esta decisión o proveer alguna información adicional, por favor contáctenos a admin@solidaritymedical.net";
                    return "d-e8266259711d4640ab40bae230cd46d5";
                case EmailPurpose.PatientNotification:
                    //return $"Estimado cliente,<br /><br />Lamentamos avisarle que su aplicación no ha sido aceptada por nuestros administradores. Si desea refutar esta decisión o proveer alguna información adicional, por favor contáctenos a admin@solidaritymedical.net";
                    return "d-d550a39a2dbe4fc8abba4c8bf4de426b";
                default:
                    return string.Empty;
            }
        }

       
        public async Task SendEmailAsync(string email, string subject, string body, string link=null)
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
                TemplateId = body,
                //Asm =
                //{
                //    GroupId = 147677,
                    //GroupsToDisplay = [ 147677 }
                //}
                //Subject = subject,
                //PlainTextContent = body,
                //HtmlContent = body
            };
            msg.SetTemplateData(new {
                Link = link,
                //Group_ID = 147677
                //Sender_Name = "SolidarityMedical",
                //Sender_Address = "4301 McQueen Dr.",
                //Sender_City = "Durham",
                //Sender_State = "NC",
                //Sender_Zip = "27705"
            });
            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);
            msg.SetAsm(147706);

            //msg.SetSubscriptionTracking(true);
            //msg.SetAsm(147677);

            await client.SendEmailAsync(msg);
        }
    }
}
