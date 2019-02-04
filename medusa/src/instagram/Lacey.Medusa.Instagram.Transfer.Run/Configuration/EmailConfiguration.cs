namespace Lacey.Medusa.Instagram.Transfer.Run.Configuration
{
    internal sealed class EmailConfiguration
    {
        public string From { get; set; }

        public string To { get; set; }

        public string SmtpHost { get; set; }

        public int SmtpPort { get; set; }

        public string SmtpUsername { get; set; }

        public string SmtpSecretFile { get; set; }

        public string Subject { get; set; }

        public bool IsSendEmails { get; set; }
    }
}