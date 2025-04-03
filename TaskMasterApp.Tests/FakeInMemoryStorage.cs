using System.Collections.Generic;
using TaskMasterApp.Models;
using TaskMasterApp.Data;

namespace TaskMasterApp.Tests
{
    /// <summary>
    /// In-memory implementation of ITodoStorage for testing.
    /// Used to simulate storage behavior without writing to disk.
    /// </summary>
    public class FakeInMemoryStorage : ITodoStorage
    {
        // Simulated storage container for todo items
        private List<Todo> _storage = new List<Todo>();

        /// <summary>
        /// Returns the current in-memory list of todos.
        /// Always succeeds and includes a fake message.
        /// </summary>
        public List<Todo> LoadTodos(out string message)
        {
            message = "Loaded todos from fake in-memory storage.";
            return _storage;
        }

        /// <summary>
        /// Overwrites the in-memory list with provided todos.
        /// Always succeeds and returns a fake success message.
        /// </summary>
        public bool SaveTodos(List<Todo> todos, out string message)
        {
            _storage = new List<Todo>(todos);
            message = "Saved todos to fake in-memory storage.";
            return true;
        }
    }
}
