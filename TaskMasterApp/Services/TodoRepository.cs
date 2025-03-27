using System.Collections.Generic;
using TaskMasterApp.Models;

namespace TaskMasterApp.Services
{
    public class TodoRepository
    {
        private readonly List<Todo> _todos = new();

        public void AddTodo(Todo todo)
        {
            _todos.Add(todo);
        }

        public List<Todo> GetAllTodos()
        {
            return _todos;
        }

        public void MarkTodoAsCompleted(Guid id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null && !todo.IsCompleted)
            {
                todo.IsCompleted = true;
            }
        }
        // Placeholder for future features:
        // public void RemoveTodo(Guid id) { ... }
        // public void UpdateTodo(Todo updatedTodo) { ... }
    }
}