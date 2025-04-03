using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TaskMasterApp.Models;

namespace TaskMasterApp.Data
{
    /// <summary>
    /// JSON-based implementation of ITodoStorage.
    /// Handles reading and writing todos to a local .json file.
    /// </summary>
    public class JsonTodoStorage : ITodoStorage
    {
        private readonly string _filePath;

        /// <summary>
        /// Sets the file path for JSON persistence.
        /// Defaults to "todos.json" in the working directory.
        /// </summary>
        public JsonTodoStorage(string filePath = "todos.json")
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Attempts to load todos from disk.
        /// Handles deserialization and returns a fallback list on error.
        /// </summary>
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

        /// <summary>
        /// Attempts to serialize and write todos to disk.
        /// Logs success or error message to the caller.
        /// </summary>
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

        /// <summary>
        /// Exposes the file path used for saving/loading todos.
        /// Useful for debugging or UI display.
        /// </summary>
        public string FilePath => _filePath;
    }
}
