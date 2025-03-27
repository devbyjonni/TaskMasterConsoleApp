using System.Collections.Generic;
using ModelTask = TaskMasterApp.Models.Task;

namespace TaskMasterApp.Services
{
    public class TaskRepository
    {
        private readonly List<ModelTask> _tasks = new();

        public void AddTask(ModelTask task)
        {
            _tasks.Add(task);
        }

        public List<ModelTask> GetAllTasks()
        {
            return _tasks;
        }

        // Placeholder for future features like RemoveTask, UpdateTask, etc.
    }
}