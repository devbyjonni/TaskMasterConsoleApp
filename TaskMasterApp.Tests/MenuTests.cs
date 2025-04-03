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
        public void ViewTasksFlow_Should_Mark_Task_As_Completed()
        {
            // Arrange
            var fakeStorage = new FakeInMemoryStorage();
            var repo = new TodoRepository(fakeStorage);
            var todo = new Todo("Test Me");
            repo.AddTodo(todo);

            // Simulate user entering the ID of the task and pressing enter again to continue
            var input = new StringReader($"{todo.Id}\n\n");
            var output = new StringWriter();
            var io = new UserInterface(input, output);

            // Act
            Menu.ViewTasksFlow(repo, io);

            // Assert
            Assert.True(repo.GetAllTodos().First().IsCompleted);
            string result = output.ToString();
            Assert.Contains("Task marked as completed!", result);
        }

    }
}