using System;

namespace Lacey.Medusa.Common.Extensions.Base
{
    internal static class SharedInstances
    {
        [ThreadStatic]
        private static Random _threadSafeRandom;

        public static Random Random => _threadSafeRandom ?? (_threadSafeRandom = new Random());
    }
}