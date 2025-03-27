using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TaskMasterApp.Models;

namespace TaskMasterApp.Data
{
    public class JsonTodoStorage : ITodoStorage
    {
        private readonly string _filePath = "todos.json";

        public List<Todo> LoadTodos()
        {
            if (!File.Exists(_filePath))
                return new List<Todo>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Todo>>(json) ?? new List<Todo>();
        }

        public void SaveTodos(List<Todo> todos)
        {
            var json = JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}