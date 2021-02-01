using Lacey.Medusa.Common.Core.Utils;

namespace Lacey.Alexa.Common.Metasploit.Utils
{
    internal static class Delay
    {
        public static void Tiny()
        {
            ConsoleUtils.WaitSec(RandomUtils.GetRandom(2, 4));
        }

        public static void Small()
        {
            ConsoleUtils.WaitSec(RandomUtils.GetRandom(8, 10));
        }
    }
}