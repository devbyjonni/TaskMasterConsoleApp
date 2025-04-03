using System;
using TaskMasterApp.Models;
using TaskMasterApp.Services;

namespace TaskMasterApp.UI
{
    public static class Menu
    {
        public static void Start(TodoRepository repository, UserInterface io)
        {
            bool exit = false;

            while (!exit)
            {
                io.WriteLine("📝 Task Master");
                io.WriteLine("1. Add a task");
                io.WriteLine("2. View all tasks");
                io.WriteLine("3. Mark task as completed");
                io.WriteLine("0. Exit");
                string choice = io.Prompt("\nChoose an option: ");

                switch (choice)
                {
                    case "1":
                        AddTaskFlow(repository, io);
                        break;
                    case "2":
                        ViewTasksFlow(repository, io);
                        break;
                    case "3":
                        MarkTaskCompletedFlow(repository, io);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        io.Pause("Invalid option. Press Enter to continue...");
                        break;
                }
            }
        }

        private static void AddTaskFlow(TodoRepository repository, UserInterface io)
        {
            string title = io.Prompt("Enter task title: ");
            var task = new Todo(title);
            repository.AddTodo(task);

            io.WriteSuccess(repository.LastStorageMessage);
            io.WriteLine("New task:");
            io.WriteSuccess($"- {task}");
            io.Pause("Task added! Press Enter to continue...");

        }


        public static void ViewTasksFlow(TodoRepository repository, UserInterface io)
        {
            var todos = repository.GetAllTodos();

            io.WriteHeader("Your Tasks");
            foreach (var todo in todos)
            {
                var display = $"- [{(todo.IsCompleted ? "x" : " ")}] {todo.Title} (ID: {todo.Id})";

                if (todo.IsCompleted)
                    io.WriteSuccess(display); // ✅ green!
                else
                    io.WriteLine(display); // normal
            }


            io.Pause("\nPress Enter to return to menu...");

        }

        public static void MarkTaskCompletedFlow(TodoRepository repository, UserInterface io)
        {
            var todos = repository.GetAllTodos();

            io.WriteHeader("Your Tasks");
            foreach (var todo in todos)
            {
                var display = $"- [{(todo.IsCompleted ? "x" : " ")}] {todo.Title} (ID: {todo.Id})";
                if (todo.IsCompleted)
                    io.WriteSuccess(display);
                else
                    io.WriteLine(display);
            }

            string idInput = io.Prompt("\nEnter the ID of the task to mark as completed: ");

            if (Guid.TryParse(idInput, out Guid todoId))
            {
                repository.MarkTodoAsCompleted(todoId);
                io.WriteSuccess(repository.LastStorageMessage);

                var completed = repository.GetAllTodos().FirstOrDefault(t => t.Id == todoId);
                if (completed != null)
                {
                    io.WriteLine("Completed task:");
                    io.WriteSuccess($"- {completed}");
                }
            }
            else if (!string.IsNullOrWhiteSpace(idInput))
            {
                io.WriteError("Invalid ID format.");
            }

            io.Pause("Press Enter to continue...");
        }
    }
}
