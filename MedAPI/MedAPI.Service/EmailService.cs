using MedAPI.Domain;
using MedAPI.Infrastructure;
using MedAPI.Infrastructure.IService;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Configuration;
using static MedAPI.Infrastructure.EmailHelper;

namespace MedAPI.Service
{
    public class EmailService : IEmailService
    {
        public string GetEmailBody(EmailPurpose purpose, string link = null)
        {
            switch (purpose)
            {
                case EmailPurpose.EmailVerification:
                    return $"Estimado cliente, <br /><br />Gracias por registrase con Solidarity Medical! Necesitamos verificar su cuenta de correo electrónico antes de continuar con la apertura de su cuenta. Por favor  <a href='{link}' >haga click </a>en el vínculo a continuación para verificar su email: <br/><br/>                     http://… <br /><br />Si usted no ha intentado registrarse con nosotros, por favor contáctenos a admin@solidaritymedical.net.< br />< br />                        Muchas gracias!Esperamos que disfrute de nuestros servicios<br />< br />Solidarity Medical < br />< br />";
                 case EmailPurpose.ForgotPassword:
                    return $"Estimado cliente,<br /><br />Hemos recibido una solicitud para restablecer su contraseña. Si usted mandó esta solicitud, por favor <a href='{link}' >haga click </a> en el enlace siguiente para escoger una nueva contraseña:< br />< br />http://<br /><br />Si no ha sido usted, por favor contáctenos a admin @solidaritymedical.net.< br />< br />Muchas gracias,< br />< br />Solidarity Medical < br />< br />";
                case EmailPurpose.ApproveAccount:
                    return $"Estimado cliente,<br /><br />Felicitaciones, su cuenta ha sido aprobada! Ahora podrá disfrutar de nuestros servicios.<br /><br />Muchas gracias,<br /><br />Solidarity Medical.<br /><br />";
                case EmailPurpose.DenyAccount:
                    return $"Estimado cliente,<br /><br />Lamentamos avisarle que su aplicación no ha sido aceptada por nuestros administradores. Si desea refutar esta decisión o proveer alguna información adicional, por favor contáctenos a admin@solidaritymedical.net";
                default:
                    return string.Empty;
            }
        }

       
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
