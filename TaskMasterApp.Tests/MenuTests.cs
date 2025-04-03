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

        [Fact]
        public void UpdateTaskFlow_Should_Update_Title_And_Show_Confirmation()
        {
            // Arrange
            var fakeStorage = new FakeInMemoryStorage();
            var repo = new TodoRepository(fakeStorage);
            var originalTodo = new Todo("Old Title");
            repo.AddTodo(originalTodo);

            // Simulate user: enter task ID, then new title, then press Enter to continue
            var input = new StringReader($"{originalTodo.Id}\nNew Title\n\n");
            var output = new StringWriter();
            var io = new UserInterface(input, output);

            // Act
            Menu.UpdateTaskFlow(repo, io);

            // Assert
            var updatedTodo = repo.GetAllTodos().FirstOrDefault(t => t.Id == originalTodo.Id);
            Assert.NotNull(updatedTodo);
            Assert.Equal("New Title", updatedTodo.Title);

            var result = output.ToString();
            Assert.Contains("Updated task:", result);
            Assert.Contains("New Title", result);
            Assert.Contains("✏️", result);
        }


    }
}