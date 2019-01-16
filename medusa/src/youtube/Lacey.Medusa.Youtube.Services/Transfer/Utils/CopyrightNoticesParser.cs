using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IReadOnlyList<CopyrightNotice>> ParseCopyrightNotices(string pageSource)
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

                    var title = contentItems[0].Text();
                    var type = contentItems[1].Text();
                    var match = contentItems[2].Text();
                    var content = new ClaimContent(title, type, TimeSpan.Zero, TimeSpan.Zero);

                    var claimantsList = new List<string>();
                    for (var j = 0; j < claimantsItems.Length - 1; j++)
                    {
                        claimantsList.Add(claimantsItems[j].Text());
                    }
                    var onBehalfOf = claimantsItems[claimantsItems.Length - 1].Text();
                    var claimants = new ClaimClaimants(claimantsList, onBehalfOf);

                    var policy = new ClaimPolicy(policyItems[0].Text());

                    var claim = new CopyrightNoticeClaim(content, claimants, policy);
                    claimsList.Add(claim);
                }

                var notice = new CopyrightNotice(null, claimsList);
                notices.Add(notice);
            }

            return notices;
        }
    }
}