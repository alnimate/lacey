using Lacey.Medusa.Common.Cli.Utils;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Utils
{
    internal class DelayUtils
    {
        public static void TaskDelay(string taskTime)
        {
            int.TryParse(taskTime, out var delay);
            if (delay <= 0)
            {
                delay = 30;
            }
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
    }
}