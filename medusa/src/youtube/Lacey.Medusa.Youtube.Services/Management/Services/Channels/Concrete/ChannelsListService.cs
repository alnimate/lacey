using Lacey.Medusa.Common.Dal.Dal;
using Lacey.Medusa.Common.Services.Services.Lists;
using Lacey.Medusa.Youtube.Domain.Entities;

namespace Lacey.Medusa.Youtube.Services.Management.Services.Channels.Concrete
{
    public sealed class ChannelsListService
        : IntIdNoRequestListService<ChannelEntity>, IChannelsListService
    {
        public ChannelsListService(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }
    }
}