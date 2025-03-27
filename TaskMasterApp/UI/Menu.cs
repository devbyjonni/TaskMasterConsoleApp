using System;
using System.IO;
using TaskMasterApp.Models;
using TaskMasterApp.Services;

namespace TaskMasterApp.UI
{
    public static class Menu
    {
        public static void Start(TodoRepository repository, TextReader input, TextWriter output)
        {
            bool exit = false;

            while (!exit)
            {
                output.WriteLine("📝 Task Master");
                output.WriteLine("1. Add a task");
                output.WriteLine("2. View all tasks");
                output.WriteLine("3. Mark task as completed");
                output.WriteLine("0. Exit");
                output.Write("\nChoose an option: ");

                string choice = input.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddTaskFlow(repository, input, output);
                        break;
                    case "2":
                        ViewTasksFlow(repository, input, output);
                        break;
                    case "3":
                        MarkTaskCompletedFlow(repository, input, output);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        output.WriteLine("Invalid option. Press Enter to continue...");
                        input.ReadLine();
                        break;
                }
            }
        }

        private static void AddTaskFlow(TodoRepository repository, TextReader input, TextWriter output)
        {
            output.Write("Enter task title: ");
            string title = input.ReadLine() ?? "Untitled";

            var task = new Todo(title);
            repository.AddTodo(task);

            output.WriteLine("Task added! Press Enter to continue...");
            input.ReadLine();
        }

        public static void ViewTasksFlow(TodoRepository repository, TextReader input, TextWriter output)
        {
            var todos = repository.GetAllTodos();

            output.WriteLine("\nYour Tasks:");
            foreach (var todo in todos)
            {
                output.WriteLine($"- [{(todo.IsCompleted ? "x" : " ")}] {todo.Title} (ID: {todo.Id})");
            }

            output.WriteLine("\nEnter the ID of the task to mark as completed (or press Enter to skip): ");
            string idInput = input.ReadLine()?.Trim();

            if (Guid.TryParse(idInput, out Guid todoId))
            {
                repository.MarkTodoAsCompleted(todoId);
                output.WriteLine("Task marked as completed!");
            }
            else if (!string.IsNullOrWhiteSpace(idInput))
            {
                output.WriteLine("Invalid ID format.");
            }

            output.WriteLine("\nPress Enter to return to menu...");
            input.ReadLine();
        }

        private static void MarkTaskCompletedFlow(TodoRepository repository, TextReader input, TextWriter output)
        {
            ViewTasksFlow(repository, input, output);
            output.Write("\nEnter the ID of the task to mark as completed: ");
            string idInput = input.ReadLine() ?? "";

            if (Guid.TryParse(idInput, out Guid id))
            {
                repository.MarkTodoAsCompleted(id);
                output.WriteLine("Task marked as completed!");
            }
            else
            {
                output.WriteLine("Invalid ID format.");
            }

            output.WriteLine("Press Enter to continue...");
            input.ReadLine();
        }
    }
}