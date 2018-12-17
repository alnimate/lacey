using System;

namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright
{
    public sealed class ClaimContent
    {
        public ClaimContent(
            string title, 
            string type, 
            TimeSpan matchStart, 
            TimeSpan matchEnd)
        {
            Title = title;
            Type = type;
            MatchStart = matchStart;
            MatchEnd = matchEnd;
        }

        public string Title { get; private set; }

        public string Type { get; private set; }

        public TimeSpan MatchStart { get; private set; }   

        public TimeSpan MatchEnd { get; private set; }   
    }
}