using System;
using TaskMasterApp.Services;
using TaskMasterApp.Models;

namespace TaskMasterApp.UI
{
    public static class Menu
    {
        public static void Start(TodoRepository repository)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("📝 Task Master");
                Console.WriteLine("1. Add a todo");
                Console.WriteLine("2. View all todos");
                Console.WriteLine("0. Exit");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddTodoFlow(repository);
                        break;
                    case "2":
                        ViewTodosFlow(repository);
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

        private static void AddTodoFlow(TodoRepository repository)
        {
            Console.Write("Enter todo title: ");
            string title = Console.ReadLine() ?? "Untitled";

            var todo = new Todo(title);
            repository.AddTodo(todo);

            Console.WriteLine("Todo added! Press Enter to continue...");
            Console.ReadLine();
        }

        private static void ViewTodosFlow(TodoRepository repository)
        {
            var todos = repository.GetAllTodos();

            Console.WriteLine("\nYour Todos:");
            foreach (var todo in todos)
            {
                Console.WriteLine($"- {todo.Title}");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}