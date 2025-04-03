using System;
using System.IO;
using System.Linq;
using TaskMasterApp.Models;
using TaskMasterApp.Services;
using TaskMasterApp.UI;
using Xunit;

namespace TaskMasterApp.Tests
{
    /// <summary>
    /// Integration-like tests for menu flows using real input/output simulation.
    /// Verifies that task operations behave as expected from a user's perspective.
    /// </summary>
    public class MenuTests
    {
        [Fact]
        public void RemoveTaskFlow_Should_Remove_Task_And_Show_Confirmation()
        {
            // Arrange: create a task and simulate user entering its ID for removal
            var fakeStorage = new FakeInMemoryStorage();
            var repo = new TodoRepository(fakeStorage);
            var todo = new Todo("Delete Me");
            repo.AddTodo(todo);

            var input = new StringReader($"{todo.Id}\n\n");
            var output = new StringWriter();
            var io = new UserInterface(input, output);

            // Act: execute the menu removal flow
            Menu.RemoveTaskFlow(repo, io);

            // Assert: task should be gone and confirmation message printed
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
            // Arrange: create a task and simulate user editing it
            var fakeStorage = new FakeInMemoryStorage();
            var repo = new TodoRepository(fakeStorage);
            var originalTodo = new Todo("Old Title");
            repo.AddTodo(originalTodo);

            var input = new StringReader($"{originalTodo.Id}\nNew Title\n\n");
            var output = new StringWriter();
            var io = new UserInterface(input, output);

            // Act: run update flow
            Menu.UpdateTaskFlow(repo, io);

            // Assert: title should be updated and reflected in output
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
            // Arrange: create tasks with varying due dates
            var fakeStorage = new FakeInMemoryStorage();
            var repo = new TodoRepository(fakeStorage);

            var task1 = new Todo("Task with later due date", DateTime.Now.AddDays(5));
            var task2 = new Todo("Task with earlier due date", DateTime.Now.AddDays(1));
            var task3 = new Todo("Task without due date");

            repo.AddTodo(task1);
            repo.AddTodo(task2);
            repo.AddTodo(task3);

            var input = new StringReader("\n");
            var output = new StringWriter();
            var io = new UserInterface(input, output);

            // Act: display tasks via menu
            Menu.ViewTasksFlow(repo, io);

            // Assert: tasks should be sorted by due date in output
            var result = output.ToString();

            var indexTask2 = result.IndexOf(task2.Title);
            var indexTask1 = result.IndexOf(task1.Title);
            var indexTask3 = result.IndexOf(task3.Title);

            Assert.True(indexTask2 < indexTask1, "Earlier due date should appear before later due date");
            Assert.True(indexTask1 < indexTask3, "Tasks without due date should appear last");
        }
    }
}
