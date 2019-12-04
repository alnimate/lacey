using System.Threading.Tasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Delegates;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services
{
    public interface ILrTasksService
    {
        event TasksCompletedDelegate OnTasksCompleted;

        Task Surf();
    }
}