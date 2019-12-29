namespace Lacey.Medusa.Common.Core.Utils
{
    public class DelayUtils
    {
        public static void Delay(string taskTime)
        {
            int.TryParse(taskTime, out var delay);
            ConsoleUtils.WaitSec(delay + RandomUtils.GetRandom(10, 60));
        }

        public static void Delay(int taskTime)
        {
            Delay(taskTime.ToString());
        }

        public static void Delay()
        {
            ConsoleUtils.WaitSec(RandomUtils.GetRandom(10, 60));
        }

        public static void SmallDelay()
        {
            ConsoleUtils.WaitSec(RandomUtils.GetRandom(10, 20));
        }

        public static void LargeDelay()
        {
            ConsoleUtils.WaitSec(RandomUtils.GetRandom(60, 120));
        }
    }
}