using System.Collections.Generic;
using TaskMasterApp.Models;
using TaskMasterApp.Data;

namespace TaskMasterApp.Services
{
    /// <summary>
    /// Provides an abstraction over task storage.
    /// Handles all operations related to managing todo items in memory and persisting them.
    /// </summary>
    public class TodoRepository
    {
        private readonly List<Todo> _todos;
        private readonly ITodoStorage _storage;

        /// <summary>
        /// Message from the most recent storage operation (load/save).
        /// Useful for communicating feedback to the UI layer.
        /// </summary>
        public string LastStorageMessage { get; private set; }

        /// <summary>
        /// Initializes the repository by loading existing todos from storage.
        /// </summary>
        /// <param name="storage">Storage implementation (e.g., JSON, DB).</param>
        public TodoRepository(ITodoStorage storage)
        {
            _storage = storage;
            _todos = _storage.LoadTodos(out var message);
            LastStorageMessage = message;
        }

        /// <summary>
        /// Adds a new todo to the list and persists it.
        /// </summary>
        public void AddTodo(Todo todo)
        {
            _todos.Add(todo);
            _storage.SaveTodos(_todos, out var message);
            LastStorageMessage = message;
        }

        /// <summary>
        /// Returns all todos currently tracked in memory.
        /// </summary>
        public List<Todo> GetAllTodos() => _todos;

        /// <summary>
        /// Marks a todo as completed by its ID and saves the update.
        /// </summary>
        public void MarkTodoAsCompleted(Guid id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.IsCompleted = true;
                _storage.SaveTodos(_todos, out var message);
                LastStorageMessage = message;
            }
        }

        /// <summary>
        /// Removes a todo by ID and updates the storage.
        /// </summary>
        public void RemoveTodo(Guid id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _todos.Remove(todo);
                _storage.SaveTodos(_todos, out var message);
                LastStorageMessage = message;
            }
            else
            {
                LastStorageMessage = "Task not found.";
            }
        }

        /// <summary>
        /// Updates the title of a todo by ID.
        /// </summary>
        public void UpdateTodo(Guid id, string newTitle)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.Title = newTitle;
                _storage.SaveTodos(_todos, out var message);
                LastStorageMessage = message;
            }
            else
            {
                LastStorageMessage = "Task not found.";
            }
        }
    }
}
