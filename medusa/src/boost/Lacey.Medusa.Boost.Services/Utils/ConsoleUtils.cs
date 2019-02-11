using System;
using System.Threading;

namespace Lacey.Medusa.Boost.Services.Utils
{
    internal static class ConsoleUtils
    {
        public static void WaitSec(int interval)
        {
            var origRow = Console.CursorTop;
            for (var i = interval; i >= 0; i--)
            {
                Console.SetCursorPosition(0, origRow);
                Console.Write("Waiting... {0} seconds left.", i);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            Console.SetCursorPosition(0, origRow);
        }
    }
}