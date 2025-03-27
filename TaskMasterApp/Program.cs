using System;
using TaskMasterApp.Services;
using TaskMasterApp.UI;

namespace TaskMasterConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            var repository = new TodoRepository();
            Menu.Start(repository, Console.In, Console.Out);
        }
    }
}