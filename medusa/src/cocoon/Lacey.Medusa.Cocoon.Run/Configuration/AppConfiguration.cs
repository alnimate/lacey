namespace Lacey.Medusa.Cocoon.Run.Configuration
{
    internal sealed class AppConfiguration
    {        
        public string TempFolder { get; set; }

        public EmailConfiguration Email { get; set; }

        public LogsConfiguration Logs { get; set; }
    }
}