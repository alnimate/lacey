using Lacey.Medusa.Common.Cli.Utils;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Utils
{
    internal class DelayUtils
    {
        public static void TaskDelay(string taskTime)
        {
            int.TryParse(taskTime, out var delay);
            ConsoleUtils.WaitSec(delay + RandomUtils.GetRandom(10, 60));
        }

        public static void TaskDelay(int taskTime)
        {
            TaskDelay(taskTime.ToString());
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