using System.Collections.Generic;

namespace Lacey.Medusa.Youtube.Transfer.Run.Models
{
    internal sealed class Channel
    {
        public string ChannelId { get; set; }

        public string Instagram { get; set; }

        public Dictionary<string, string> Replacements { get; set; }
    }
}