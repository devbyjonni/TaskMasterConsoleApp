using System.Collections.Generic;
using TaskMasterApp.Models;
using TaskMasterApp.Data;

namespace TaskMasterApp.Services
{
    public class TodoRepository
    {
        private readonly List<Todo> _todos;
        private readonly ITodoStorage _storage;
        public string LastStorageMessage { get; private set; }

        public TodoRepository(ITodoStorage storage)
        {
            _storage = storage;
            _todos = _storage.LoadTodos(out var message);
            LastStorageMessage = message;
        }

        public void AddTodo(Todo todo)
        {
            _todos.Add(todo);
            _storage.SaveTodos(_todos, out var message);
            LastStorageMessage = message;
        }

        public List<Todo> GetAllTodos() => _todos;

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
    }

}