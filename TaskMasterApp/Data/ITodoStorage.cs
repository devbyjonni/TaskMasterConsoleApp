using System.Collections.Generic;
using TaskMasterApp.Models;

namespace TaskMasterApp.Data
{
    public interface ITodoStorage
    {
        List<Todo> LoadTodos(out string message);
        bool SaveTodos(List<Todo> todos, out string message);
    }
}
