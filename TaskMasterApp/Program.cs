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
            Menu.Start(repository, Console.In, Console.Out);

        }
    }
}