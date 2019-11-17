using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using Lacey.Medusa.Surfer.Services.LikesRock.Const;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetStats;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetTasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.SignIn;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Extensions
{
    internal static class HtmlExtensions
    {
        public static SignInBvbResponseModel GetSignInResponse(this string html)
        {
            var bvb = string.Empty;

            var match = Regex.Match(html, @".*BVB45629\s*=\s*(\w+)\s*"";\s*document.*", RegexOptions.Multiline);
            if (match.Groups.Count > 1)
            {
                bvb = match.Groups[1].Value;
            }

            return new SignInBvbResponseModel
            {
                Bvb = bvb
            };
        }

        public static async Task<GetTasksResponseModel> GetTasksResponse(this string html)
        {
            var list = new List<GetTasksItemModel>();
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(html);
            var rows = document.QuerySelectorAll("table tbody tr")
                .Where(e => e.HasAttribute("id"))
                .ToArray();

            foreach (var row in rows)
            {
                if (!int.TryParse(row.Id.Replace("task_", string.Empty), out var taskId))
                {
                    continue;
                }

                var a = row.QuerySelectorAll("a").FirstOrDefault();
                var href = a?.Attributes.GetNamedItem("href");
                if (href == null)
                {
                    continue;
                }
                var taskUrl = href.Value;

                var cls = a.Attributes.GetNamedItem("class");
                if (cls == null)
                {
                    continue;
                }

                var taskTime = 0;
                var match = Regex.Match(cls.Value, @".*time_(\w+)_time.*", RegexOptions.Multiline);
                if (match.Groups.Count > 1)
                {
                    if (!int.TryParse(match.Groups[1].Value, out taskTime))
                    {
                        continue;
                    }
                }

                var strong = row.QuerySelectorAll("td strong").FirstOrDefault();
                if (strong == null)
                {
                    continue;
                }
                
                string currency;
                float money;
                var arr = strong.InnerHtml.Split(new []{ ";" }, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length < 2)
                {
                    currency = Currency.Euro;
                    try
                    {
                        money = float.Parse(arr[0].Replace(Currency.Euro, string.Empty), CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                else
                {
                    currency = arr[0].Replace("&nbsp", string.Empty)
                        .Replace("&", string.Empty)
                        .Replace("euro", Currency.Euro);

                    try
                    {
                        money = float.Parse(arr[1], CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                list.Add(new GetTasksItemModel
                {
                    TaskId = taskId,
                    TaskUrl = taskUrl,
                    TaskTime = taskTime,
                    Money = money,
                    Currency = currency
                });
            }

            return new GetTasksResponseModel
            {
                Tasks = list.ToArray()
            };
        }


        public static async Task<GetStatsResponseModel> GetStatsResponse(this string html)
        {
            var list = new List<GetStatsItemModel>();
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(html);
            var rows = document.QuerySelectorAll("table tbody tr").ToArray();

            foreach (var row in rows)
            {
                var tds = row.QuerySelectorAll("td");
                if (tds.Length < 6)
                {
                    continue;
                }

                var socialNetwork = GetContent(tds[0].TextContent);
                var socialAccountId = GetContent(tds[1].TextContent);
                var firstUse = GetContent(tds[2].TextContent);
                var lastUse = GetContent(tds[3].TextContent);
                var tasks = GetContent(tds[4].TextContent);
                var totalEarnings = GetContent(tds[5].TextContent);

                list.Add(new GetStatsItemModel
                {
                    SocialNetwork = socialNetwork,
                    SocialAccountId = socialAccountId,
                    FirstUse = firstUse,
                    LastUse = lastUse,
                    Tasks = tasks,
                    TotalEarnings = totalEarnings
                });
            }

            return new GetStatsResponseModel
            {
                Items = list.ToArray()
            };
        }

        private static string GetContent(string text)
        {
            if (text == null)
            {
                return string.Empty;
            }

            return text
                .Replace("\n", string.Empty)
                .Trim()
                .Replace(Currency.Euro, $"{Currency.EuroStr} ");
        }
    }
}