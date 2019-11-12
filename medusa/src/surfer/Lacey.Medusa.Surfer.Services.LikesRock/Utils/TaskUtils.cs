using Lacey.Medusa.Common.Cli.Utils;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Utils
{
    internal class TaskUtils
    {
        public static void Delay(string taskTime)
        {
            int.TryParse(taskTime, out var delay);
            if (delay <= 0)
            {
                delay = 30;
            }
            ConsoleUtils.WaitSec(delay + 1);
        }

        public static void Delay(int taskTime)
        {
            Delay(taskTime.ToString());
        }
    }
}