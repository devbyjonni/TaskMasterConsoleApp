using System;
using System.IO;
using System.Linq;
using TaskMasterApp.Models;
using TaskMasterApp.Services;
using TaskMasterApp.UI;
using Xunit;

namespace TaskMasterApp.Tests
{
    public class MenuTests
    {
        [Fact]
        public void RemoveTaskFlow_Should_Remove_Task_And_Show_Confirmation()
        {
            // Arrange
            var fakeStorage = new FakeInMemoryStorage();
            var repo = new TodoRepository(fakeStorage);
            var todo = new Todo("Delete Me");
            repo.AddTodo(todo);

            var input = new StringReader($"{todo.Id}\n\n");
            var output = new StringWriter();
            var io = new UserInterface(input, output);

            // Act
            Menu.RemoveTaskFlow(repo, io);

            // Assert
            var all = repo.GetAllTodos();
            Assert.DoesNotContain(all, t => t.Id == todo.Id);

            var result = output.ToString();
            Assert.Contains("Removed task:", result);
            Assert.Contains("🗑️", result);
            Assert.Contains(todo.Title, result);
        }

    }
}