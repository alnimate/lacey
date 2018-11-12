using System.Collections.Generic;

namespace Lacey.Medusa.Common.Email.Services.Email
{
    public interface IEmailProvider
    {
        void Send(string from,
            string to,
            string subject,
            string body,
            bool isBodyHtml,
            IEnumerable<string> files);
    }
}