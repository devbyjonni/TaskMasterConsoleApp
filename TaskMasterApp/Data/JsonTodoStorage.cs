using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TaskMasterApp.Models;

namespace TaskMasterApp.Data
{
    public class JsonTodoStorage : ITodoStorage
    {
        private readonly string _filePath;

        public JsonTodoStorage(string filePath = "todos.json")
        {
            _filePath = filePath;
        }

        public List<Todo> LoadTodos(out string message)
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    message = $"No file found. Starting with an empty list. Path: {_filePath}";
                    return new List<Todo>();
                }

                var json = File.ReadAllText(_filePath);
                var todos = JsonSerializer.Deserialize<List<Todo>>(json) ?? new List<Todo>();

                message = $"Loaded {todos.Count} todos from {_filePath}";
                return todos;
            }
            catch (Exception ex)
            {
                message = $"Failed to load todos: {ex.Message}";
                return new List<Todo>();
            }
        }

        public bool SaveTodos(List<Todo> todos, out string message)
        {
            try
            {
                var json = JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
                message = $"Saved {todos.Count} todos to {_filePath}";
                return true;
            }
            catch (Exception ex)
            {
                message = $"Failed to save todos: {ex.Message}";
                return false;
            }
        }

        // ✅ This goes *outside* the SaveTodos method
        public string FilePath => _filePath;
    }
}
