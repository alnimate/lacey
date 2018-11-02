namespace Lacey.Medusa.Common.Services.Services.Statistics.Interfaces
{
    using Lacey.Medusa.Common.Services.Models.Statistics;
    public interface INoRequestStatisticsService<TData> : IStatisticsService<EmptyStatisticsRequest, TData>
    {        
    }
}