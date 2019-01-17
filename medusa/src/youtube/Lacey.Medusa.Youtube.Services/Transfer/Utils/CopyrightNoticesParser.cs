using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright;

namespace Lacey.Medusa.Youtube.Services.Transfer.Utils
{
    internal sealed class CopyrightNoticesParser
    {
        private readonly HtmlParser parser;

        public CopyrightNoticesParser()
        {
            this.parser = new HtmlParser();
        }

        public async Task<IReadOnlyList<string>> ParseVideosCopyright(string pageSource)
        {
            var urls = new List<string>();
            var document = await this.parser.ParseDocumentAsync(pageSource);
            var items = document.All.Where(e => e.LocalName == "a" && e.HasAttribute("data-url"));

            foreach (var item in items)
            {
                var url = item.GetAttribute("data-url");
                if (url.StartsWith("/video_copynotice?v="))
                {
                    urls.Add(url);
                }
            }

            return urls;
        }

        public async Task<IReadOnlyList<CopyrightNotice>> ParseCopyrightNotices(
            string videoId,
            string pageSource)
        {
            var notices = new List<CopyrightNotice>();
            var document = await this.parser.ParseDocumentAsync(pageSource);
            var rows = document.QuerySelectorAll("table.copynotice-claim-details-table tbody tr");
            if (rows != null && rows.Any())
            {
                var claimsList = new List<CopyrightNoticeClaim>();
                for (var i = 1; i < rows.Length; i++)
                {
                    var row = rows[i];
                    var columns = row.QuerySelectorAll("td");
                    var contentItems = columns[0].QuerySelectorAll("li");
                    var claimantsItems = columns[1].QuerySelectorAll("li");
                    var policyItems = columns[2].QuerySelectorAll("li");

                    var title = contentItems[0].GetText();
                    var type = contentItems[1].GetText();
                    var match = ParseInterval(contentItems[2].GetText());
                    var content = new ClaimContent(title, type, match[0], match[1]);

                    var claimantsList = new List<string>();
                    for (var j = 0; j < claimantsItems.Length - 1; j++)
                    {
                        claimantsList.Add(claimantsItems[j].GetText());
                    }
                    var onBehalfOf = claimantsItems[claimantsItems.Length - 1].GetText();
                    var claimants = new ClaimClaimants(claimantsList, onBehalfOf);

                    var policy = new ClaimPolicy(policyItems[0].GetText());

                    var claim = new CopyrightNoticeClaim(content, claimants, policy);
                    claimsList.Add(claim);
                }

                var notice = new CopyrightNotice(videoId, claimsList);
                notices.Add(notice);
            }

            return notices;
        }

        private static TimeSpan[] ParseInterval(string str)
        {
            const string time = @"(?:(?:([01]?\d|2[0-3]):)?([0-5]?\d):)?([0-5]?\d)";
            var match = Regex.Match(str, $"\\.*{time}\\s*-\\s*{time}\\.*");

            if (match.Groups.Count != 7)
            {
                return new []
                {
                    TimeSpan.Zero, 
                    TimeSpan.Zero
                };
            }

            return new []
            {
                new TimeSpan(0, 
                    string.IsNullOrEmpty(match.Groups[1].Value) ? 0 : int.Parse(match.Groups[1].Value),
                    int.Parse(match.Groups[2].Value),
                    int.Parse(match.Groups[3].Value)), 
                new TimeSpan(0, 
                    string.IsNullOrEmpty(match.Groups[4].Value) ? 0 : int.Parse(match.Groups[4].Value),
                    int.Parse(match.Groups[5].Value),
                    int.Parse(match.Groups[6].Value)), 
            };
        }
    }
}