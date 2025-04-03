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
            var storage = new JsonTodoStorage();
            var repository = new TodoRepository(storage);
            var io = new UserInterface(Console.In, Console.Out);

            Menu.Start(repository, io);
        }
    }
}
