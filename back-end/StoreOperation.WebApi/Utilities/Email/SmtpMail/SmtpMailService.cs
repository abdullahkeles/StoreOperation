using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using StoreOperation.WebApi.Configuration.Context;

namespace StoreOperation.WebApi.Utilities.Email.SmtpMail
{
    public class SmtpMailService : IMailService
    {
        private readonly IStoreOperationConfigurationContext checkListConfigurationContext;

        public SmtpMailService(IStoreOperationConfigurationContext checkListConfigurationContext)
        {
            this.checkListConfigurationContext = checkListConfigurationContext;
        }


        public async Task SendEmailAsync(IEnumerable<string> to, string subject, string body, bool isBodyHtml = true)
        {
            using (MailMessage mail = new MailMessage())
            {
                using (SmtpClient SmtpServer = new SmtpClient(checkListConfigurationContext.SmtpHost))
                {
                    mail.From = new MailAddress(checkListConfigurationContext.SmtpEmail);

                    foreach (var email in to)
                    {
                        mail.To.Add(email);
                    }

                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = isBodyHtml;

                    SmtpServer.Port = checkListConfigurationContext.SmtpPort;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(checkListConfigurationContext.SmtpEmail, checkListConfigurationContext.SmtpPassword);
                    SmtpServer.EnableSsl = true;

                    await SmtpServer.SendMailAsync(mail);
                }
            }
        }
    }
}
