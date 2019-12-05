using System;
using System.Globalization;
using Lacey.Medusa.Surfer.Services.LikesRock.Const;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Extensions
{
    internal static class MoneyExtensions
    {
        public static float ParseMoney(this string moneyStr)
        {
            if (string.IsNullOrEmpty(moneyStr))
            {
                return 0;
            }

            try
            {
                return float.Parse(moneyStr.NormalizeMoney(), CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static string NormalizeMoney(this string moneyStr)
        {
            if (string.IsNullOrEmpty(moneyStr))
            {
                return string.Empty;
            }

            return moneyStr
                .Replace(Currency.EuroStr, string.Empty, StringComparison.OrdinalIgnoreCase)
                .Replace(Currency.Msh, string.Empty, StringComparison.OrdinalIgnoreCase)
                .Replace(Currency.Euro, string.Empty, StringComparison.OrdinalIgnoreCase)
                .Trim();
        }
    }
}