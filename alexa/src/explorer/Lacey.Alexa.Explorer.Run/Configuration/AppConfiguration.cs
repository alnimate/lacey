namespace Lacey.Alexa.Explorer.Run.Configuration
{
    internal sealed class AppConfiguration
    {
        public string TempFolder { get; set; }

        public LogsConfiguration Logs { get; set; }

        public MetasploitConfiguration Metasploit { get; set; }

        public ShodanConfiguration Shodan { get; set; }
    }
}