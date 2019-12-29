using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Common.Core.Utils
{
    public static class ProceedUtils
    {
        private const byte ErrorsLimit = 3;

        public static async Task<TResult> Proceed<TResult>(ILogger logger, Func<Task<TResult>> action)
        {
            var errors = 0;
            while (true)
            {
                try
                {
                    var result = await action();
                    if (!result.Equals(default))
                    {
                        return result;
                    }
                    DelayUtils.LargeDelay();
                }
                catch (Exception e)
                {
                    logger.LogError(e.Message);
                    errors++;
                    if (errors > ErrorsLimit)
                    {
                        logger.LogError($"Errors limit ({ErrorsLimit}) exceeded. Closing...");
                        DelayUtils.LargeDelay();
                        return default;
                    }
                    DelayUtils.LargeDelay();
                }
            }
        }
    }
}