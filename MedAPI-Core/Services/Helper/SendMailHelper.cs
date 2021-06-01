using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public class SendMailHelper
    {
        public async Task Send(string subject, string body, List<string> to)
        {
            await Task.Run(() =>
            {
                MailMessage mail;
                SmtpClient SmtpServer;
                try
                {
                    mail = new MailMessage();
                    SmtpServer = new SmtpClient();
                    SmtpServer.Host = ConfigurationManager.AppSettings.Get("HOST");
                    mail.From = new MailAddress(ConfigurationManager.AppSettings.Get("FROM"));

                    if (to!=null)
                    {
                        foreach (var addto in to)
                        {
                            mail.To.Add(addto);
                        }
                    }
                  
                    mail.Subject = subject;
                    mail.Priority = MailPriority.Normal;
                    mail.IsBodyHtml = true;
                    mail.Body = body;

                   
                    SmtpServer.Port =Convert.ToInt32(ConfigurationManager.AppSettings.Get("PORT"));
                    SmtpServer.EnableSsl = true; 
                    SmtpServer.Timeout = 10000;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("SMTP_USERNAME"), ConfigurationManager.AppSettings.Get("SMTP_PASSWORD"));
                    SmtpServer.Send(mail);
                    SmtpServer.Dispose();
                    mail.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    mail = null;
                    SmtpServer = null;
                }
            });
        }
    }
}
