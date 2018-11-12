using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using Lacey.Medusa.Common.Email.Services.Auth;

namespace Lacey.Medusa.Common.Email.Services.Email.Concrete
{
    public class EmailProvider : IEmailProvider
    {
        private readonly SmtpClient smtpClient;

        public EmailProvider(
            string smtpHost,
            int smtpPort,
            IEmailAuthProvider authProvider)
        {
            this.smtpClient = new SmtpClient(smtpHost, smtpPort);
            this.smtpClient.EnableSsl = true;
            this.smtpClient.UseDefaultCredentials = false;
            this.smtpClient.Credentials = new NetworkCredential(authProvider.Username, 
                authProvider.Password);
        }

        public void Send(string @from, 
            string to, 
            string subject, 
            string body,
            bool isBodyHtml,
            IEnumerable<string> files)
        {
            var message = new MailMessage();
            message.From = new MailAddress(@from);
            message.To.Add(to);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isBodyHtml;
            if (files != null)
            {
                foreach (var filePath in files)
                {
                    var attachment = new Attachment(filePath);
                    message.Attachments.Add(attachment);
                }
            }
            this.smtpClient.Send(message);
        }
    }
}