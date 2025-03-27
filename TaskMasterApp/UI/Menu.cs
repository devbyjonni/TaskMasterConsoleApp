using System;
using TaskMasterApp.Services;
using ModelTask = TaskMasterApp.Models.Task;

namespace TaskMasterApp.UI
{
    public static class Menu
    {
        public static void Start(TaskRepository repository)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("📝 Task Master");
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. View all tasks");
                Console.WriteLine("0. Exit");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddTaskFlow(repository);
                        break;
                    case "2":
                        ViewTasksFlow(repository);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void AddTaskFlow(TaskRepository repository)
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine() ?? "Untitled";

            var task = new ModelTask(title: "New Task");

            repository.AddTask(task);

            Console.WriteLine("Task added! Press Enter to continue...");
            Console.ReadLine();
        }

        private static void ViewTasksFlow(TaskRepository repository)
        {
            var tasks = repository.GetAllTasks();

            Console.WriteLine("\nYour Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"- {task.Title}");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}