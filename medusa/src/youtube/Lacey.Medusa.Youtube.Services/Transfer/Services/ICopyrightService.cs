using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Copyright;

namespace Lacey.Medusa.Youtube.Services.Transfer.Services
{
    public interface ICopyrightService
    {
        Task<IReadOnlyList<CopyrightNotice>> GetCopyrightNotices(string channelId);
    }
}