using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetSurfUrl;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetTasks;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Extensions
{
    internal static class TaskExtensions
    {
        public static bool NoAutoSurf(this GetSurfUrlResponseModel surf)
        {
            int.TryParse(surf.TaskId, out var taskId);

            return taskId <= 0;
        }

        public static bool NoSurf(this GetTasksItemModel surf)
        {
            return surf.TaskId <= 0;
        }
    }
}