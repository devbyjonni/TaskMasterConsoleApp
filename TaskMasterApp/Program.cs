using System;
using TaskMasterApp.Services;
using TaskMasterApp.UI;
using TaskMasterApp.Data;

namespace TaskMasterConsoleApp
{
    /// <summary>
    /// Entry point for the TaskMaster console application.
    /// Responsible for wiring up dependencies and launching the UI.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            // Initialize storage (JSON file by default)
            var storage = new JsonTodoStorage();

            // Create the repository with storage dependency
            var repository = new TodoRepository(storage);

            // Setup I/O wrapper for testability and cleaner UI
            var io = new UserInterface(Console.In, Console.Out);

            // Display file path info at startup
            io.WriteSuccess($"[Data] Saving todos at: {storage.FilePath}");

            // Launch the menu-driven application loop
            Menu.Start(repository, io);
        }
    }
}
