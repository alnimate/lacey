using System;

namespace Lacey.Medusa.Boost.Services.Utils
{
    internal static class RandomUtils
    {
        private static readonly Random Random = new Random();

        public static int GetRandom(int min, int max)
        {
            return Random.Next(min, max);
        }

        public static bool GetRandom()
        {
            return Random.Next(0, 1) > 0;
        }
    }
}