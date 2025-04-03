using System;
using TaskMasterApp.Services;
using TaskMasterApp.UI;
using TaskMasterApp.Data;

namespace TaskMasterConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            // Setup dependencies
            var storage = new JsonTodoStorage();
            var repository = new TodoRepository(storage);
            var io = new UserInterface(Console.In, Console.Out);

            // Show where data is being saved
            io.WriteLine($"[Data] Saving todos at: {storage.FilePath}");

            // Start the app
            Menu.Start(repository, io);
        }
    }
}
