using System.Collections.Generic;
using TaskMasterApp.Models;

namespace TaskMasterApp.Data
{
    /// <summary>
    /// Defines a contract for todo persistence mechanisms (e.g., file, DB).
    /// Enables swapping storage strategies without affecting app logic.
    /// </summary>
    public interface ITodoStorage
    {
        /// <summary>
        /// Loads all todos from the storage medium.
        /// </summary>
        /// <param name="message">Describes the result of the load operation.</param>
        /// <returns>A list of todo items.</returns>
        List<Todo> LoadTodos(out string message);

        /// <summary>
        /// Saves all todos to the storage medium.
        /// </summary>
        /// <param name="todos">The list of todos to persist.</param>
        /// <param name="message">Describes the result of the save operation.</param>
        /// <returns>True if save was successful, otherwise false.</returns>
        bool SaveTodos(List<Todo> todos, out string message);
    }
}
