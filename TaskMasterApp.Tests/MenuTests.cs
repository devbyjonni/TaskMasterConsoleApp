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

        [Fact]
        public void ViewTasksFlow_Should_Display_Tasks_Sorted_By_DueDate()
        {
            // Arrange
            var fakeStorage = new FakeInMemoryStorage();
            var repo = new TodoRepository(fakeStorage);

            var task1 = new Todo("Task with later due date", DateTime.Now.AddDays(5));
            var task2 = new Todo("Task with earlier due date", DateTime.Now.AddDays(1));
            var task3 = new Todo("Task without due date");

            repo.AddTodo(task1);
            repo.AddTodo(task2);
            repo.AddTodo(task3);

            var input = new StringReader("\n"); // simulate pressing Enter to return to menu
            var output = new StringWriter();
            var io = new UserInterface(input, output);

            // Act
            Menu.ViewTasksFlow(repo, io);

            // Assert: check the order of tasks in the output
            var result = output.ToString();

            var indexTask2 = result.IndexOf(task2.Title);
            var indexTask1 = result.IndexOf(task1.Title);
            var indexTask3 = result.IndexOf(task3.Title);

            Assert.True(indexTask2 < indexTask1, "Earlier due date should appear before later due date");
            Assert.True(indexTask1 < indexTask3, "Tasks without due date should appear last");
        }

    }
}