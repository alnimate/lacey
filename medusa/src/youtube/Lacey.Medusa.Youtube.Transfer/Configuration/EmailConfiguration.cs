namespace Lacey.Medusa.Youtube.Transfer.Configuration
{
    public sealed class EmailConfiguration
    {
        public string From { get; set; }

        public string To { get; set; }

        public string SmtpHost { get; set; }

        public int SmtpPort { get; set; }

        public string SmtpUsername { get; set; }

        public string SmtpSecretFile { get; set; }
    }
}