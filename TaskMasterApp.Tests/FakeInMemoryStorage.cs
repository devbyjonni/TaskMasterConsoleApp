using System.Collections.Generic;
using TaskMasterApp.Data;
using TaskMasterApp.Models;

namespace TaskMasterApp.Tests
{
    public class FakeInMemoryStorage : ITodoStorage
    {
        public List<Todo> StoredTodos { get; private set; } = new();

        public List<Todo> LoadTodos()
        {
            return StoredTodos;
        }

        public void SaveTodos(List<Todo> todos)
        {
            StoredTodos = new List<Todo>(todos); // simulate saving
        }
    }
}