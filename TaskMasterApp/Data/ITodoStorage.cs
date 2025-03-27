using System.Collections.Generic;
using TaskMasterApp.Models;

namespace TaskMasterApp.Data
{
    /// <summary>
    /// Defines the contract for loading and saving todos.
    /// Allows swapping storage methods (e.g., JSON file, database) without changing the rest of the app.
    /// </summary>
    public interface ITodoStorage
    {
        /// <summary>
        /// Loads todos from the storage medium.
        /// </summary>
        /// <returns>A list of todos.</returns>
        List<Todo> LoadTodos();

        /// <summary>
        /// Persists todos to the storage medium.
        /// </summary>
        /// <param name="todos">The list of todos to save.</param>
        void SaveTodos(List<Todo> todos);
    }
}