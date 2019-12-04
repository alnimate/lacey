using System.Collections.Generic;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Tasks;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Delegates
{
    public delegate void TasksCompletedDelegate(List<TaskCompleted> tasksCompleted);
}