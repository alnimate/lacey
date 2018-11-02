namespace Lacey.Medusa.Common.Services.Services.Lists.Interfaces
{
    using System.Threading.Tasks;

    using Lacey.Medusa.Common.Services.Models.Lists;

    public interface IModelsListService<TRequest>
    {
        Task<ModelsList<TRequest>> GetList(TRequest request);
    }
}