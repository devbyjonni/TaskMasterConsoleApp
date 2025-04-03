using System.Collections.Generic;
using TaskMasterApp.Models;
using TaskMasterApp.Data;

namespace TaskMasterApp.Tests
{
    public class FakeInMemoryStorage : ITodoStorage
    {
        private List<Todo> _storage = new List<Todo>();

        public List<Todo> LoadTodos(out string message)
        {
            message = "Loaded todos from fake in-memory storage.";
            return _storage;
        }

        public bool SaveTodos(List<Todo> todos, out string message)
        {
            _storage = new List<Todo>(todos);
            message = "Saved todos to fake in-memory storage.";
            return true;
        }
    }
}
