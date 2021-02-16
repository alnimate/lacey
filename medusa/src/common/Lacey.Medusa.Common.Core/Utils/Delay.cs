namespace Lacey.Medusa.Common.Core.Utils
{
    public static class Delay
    {
        public static void Tiny()
        {
            ConsoleUtils.WaitSec(RandomUtils.GetRandom(2, 4));
        }

        public static void Small()
        {
            ConsoleUtils.WaitSec(RandomUtils.GetRandom(8, 10));
        }

        public static void Huge()
        {
            ConsoleUtils.WaitSec(RandomUtils.GetRandom(60, 120));
        }
    }
}