using Lacey.Medusa.Surfer.Services.LikesRock.Models.GetTasks;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.RecordAction;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.Tasks
{
    public sealed class TaskCompleted
    {
        public GetTasksItemModel Task { get; }

        public RecordActionResponseModel RecordAction { get; }

        public TaskCompleted(GetTasksItemModel task, RecordActionResponseModel recordAction)
        {
            Task = task;
            RecordAction = recordAction;
        }
    }
}