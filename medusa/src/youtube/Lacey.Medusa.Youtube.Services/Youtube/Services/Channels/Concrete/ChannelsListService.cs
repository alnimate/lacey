using Lacey.Medusa.Common.Dal.Infrastructure;
using Lacey.Medusa.Common.Services.Services.Lists;
using Lacey.Medusa.Youtube.Domain.Entities;

namespace Lacey.Medusa.Youtube.Services.Youtube.Services.Channels.Concrete
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