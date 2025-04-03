using System;
using System.Linq;
using TaskMasterApp.Models;
using TaskMasterApp.Services;

namespace TaskMasterApp.UI
{
    /// <summary>
    /// Handles all user interaction flows through a menu-based console UI.
    /// Each case delegates to a task-specific operation (Add, View, Complete, etc.).
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Displays the main menu and routes input to task flows.
        /// </summary>
        public static void Start(TodoRepository repository, UserInterface io)
        {
            bool exit = false;

            while (!exit)
            {
                io.WriteLine("📝 Task Master");
                io.WriteLine("1. Add a task");
                io.WriteLine("2. View all tasks");
                io.WriteLine("3. Mark task as completed");
                io.WriteLine("4. Remove a task");
                io.WriteLine("5. Update a task");
                io.WriteLine("0. Exit");

                string choice = io.Prompt("\nChoose an option: ");

                switch (choice)
                {
                    case "1": AddTaskFlow(repository, io); break;
                    case "2": ViewTasksFlow(repository, io); break;
                    case "3": MarkTaskCompletedFlow(repository, io); break;
                    case "4": RemoveTaskFlow(repository, io); break;
                    case "5": UpdateTaskFlow(repository, io); break;
                    case "0": exit = true; break;
                    default: io.Pause("Invalid option. Press Enter to continue..."); break;
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter a task title and optional due date.
        /// Saves the task to the repository and shows a confirmation.
        /// </summary>
        private static void AddTaskFlow(TodoRepository repository, UserInterface io)
        {
            string title = io.Prompt("Enter task title: ");
            string dueInput = io.Prompt("Enter due date (yyyy-mm-dd) or leave empty: ");

            DateTime? dueDate = null;
            if (DateTime.TryParse(dueInput, out var parsedDate))
                dueDate = parsedDate;

            var task = new Todo(title, dueDate);
            repository.AddTodo(task);

            io.WriteSuccess(repository.LastStorageMessage);
            io.WriteLine("🆕 New task:");
            io.WriteSuccess($"- {task}");
            io.Pause("Task added! Press Enter to continue...");
        }

        /// <summary>
        /// Displays all tasks sorted by due date (earliest first).
        /// Completed tasks are shown in green with checkmarks.
        /// </summary>
        public static void ViewTasksFlow(TodoRepository repository, UserInterface io)
        {
            var todos = repository.GetAllTodos()
                .OrderBy(t => t.DueDate ?? DateTime.MaxValue)
                .ToList();

            io.WriteHeader("Your Tasks");
            foreach (var todo in todos)
            {
                var due = todo.DueDate.HasValue ? $" (Due: {todo.DueDate:yyyy-MM-dd})" : "";
                var display = $"- [{(todo.IsCompleted ? "x" : " ")}] {todo.Title}{due} (ID: {todo.Id})";

                if (todo.IsCompleted)
                    io.WriteSuccess(display);
                else
                    io.WriteLine(display);
            }

            io.Pause("\nPress Enter to return to menu...");
        }

        /// <summary>
        /// Marks a task as completed by its GUID and confirms the action.
        /// </summary>
        public static void MarkTaskCompletedFlow(TodoRepository repository, UserInterface io)
        {
            var todos = repository.GetAllTodos()
                .OrderBy(t => t.DueDate ?? DateTime.MaxValue)
                .ToList();

            io.WriteHeader("Your Tasks");
            foreach (var todo in todos)
            {
                var due = todo.DueDate.HasValue ? $" (Due: {todo.DueDate:yyyy-MM-dd})" : "";
                var display = $"- [{(todo.IsCompleted ? "x" : " ")}] {todo.Title}{due} (ID: {todo.Id})";

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
                    io.WriteLine("✅ Completed task:");
                    io.WriteSuccess($"- {completed}");
                }
            }
            else if (!string.IsNullOrWhiteSpace(idInput))
            {
                io.WriteError("Invalid ID format.");
            }

            io.Pause("Press Enter to continue...");
        }

        /// <summary>
        /// Removes a task by its ID and shows a confirmation with trash emoji.
        /// </summary>
        public static void RemoveTaskFlow(TodoRepository repository, UserInterface io)
        {
            var todos = repository.GetAllTodos()
                .OrderBy(t => t.DueDate ?? DateTime.MaxValue)
                .ToList();

            io.WriteHeader("Your Tasks");
            foreach (var todo in todos)
            {
                var due = todo.DueDate.HasValue ? $" (Due: {todo.DueDate:yyyy-MM-dd})" : "";
                var display = $"- [{(todo.IsCompleted ? "x" : " ")}] {todo.Title}{due} (ID: {todo.Id})";

                if (todo.IsCompleted)
                    io.WriteSuccess(display);
                else
                    io.WriteLine(display);
            }

            string idInput = io.Prompt("\nEnter the ID of the task to remove: ");

            if (Guid.TryParse(idInput, out Guid todoId))
            {
                var toRemove = todos.FirstOrDefault(t => t.Id == todoId);
                repository.RemoveTodo(todoId);

                if (toRemove != null)
                {
                    io.WriteSuccess(repository.LastStorageMessage);
                    io.WriteSuccess("Removed task:");
                    io.WriteLine($"🗑️  {toRemove}");
                }
                else
                {
                    io.WriteError("Task not found.");
                }
            }
            else
            {
                io.WriteError("Invalid ID format.");
            }

            io.Pause("Press Enter to continue...");
        }

        /// <summary>
        /// Updates the title of an existing task by ID and shows the updated result.
        /// </summary>
        public static void UpdateTaskFlow(TodoRepository repository, UserInterface io)
        {
            var todos = repository.GetAllTodos()
                .OrderBy(t => t.DueDate ?? DateTime.MaxValue)
                .ToList();

            io.WriteHeader("Your Tasks");
            foreach (var todo in todos)
            {
                var due = todo.DueDate.HasValue ? $" (Due: {todo.DueDate:yyyy-MM-dd})" : "";
                var display = $"- [{(todo.IsCompleted ? "x" : " ")}] {todo.Title}{due} (ID: {todo.Id})";

                if (todo.IsCompleted)
                    io.WriteSuccess(display);
                else
                    io.WriteLine(display);
            }

            string idInput = io.Prompt("\nEnter the ID of the task to update: ");

            if (Guid.TryParse(idInput, out Guid todoId))
            {
                var toUpdate = todos.FirstOrDefault(t => t.Id == todoId);
                if (toUpdate != null)
                {
                    string newTitle = io.Prompt($"Enter new title for '{toUpdate.Title}': ");
                    repository.UpdateTodo(todoId, newTitle);

                    io.WriteSuccess(repository.LastStorageMessage);
                    io.WriteSuccess("Updated task:");
                    io.WriteSuccess($"✏️  - {toUpdate}");
                }
                else
                {
                    io.WriteError("Task not found.");
                }
            }
            else
            {
                io.WriteError("Invalid ID format.");
            }

            io.Pause("Press Enter to continue...");
        }
    }
}
