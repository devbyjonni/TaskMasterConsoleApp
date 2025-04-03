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
    /// Unit tests for core task logic and interactive flows.
    /// Combines repository logic and UI input/output simulation.
    /// </summary>
    public class TodoRepositoryTests
    {
        [Fact]
        public void AddTodo_Should_Add_To_List()
        {
            // Arrange: create fake storage and repository
            var fakeStorage = new FakeInMemoryStorage();
            var repo = new TodoRepository(fakeStorage);
            var todo = new Todo("Test Todo");

            // Act: add a task and fetch current list
            repo.AddTodo(todo);
            var todos = repo.GetAllTodos();

            // Assert: ensure the list contains exactly one task with correct title
            Assert.Single(todos);
            Assert.Equal("Test Todo", todos.First().Title);
        }

        [Fact]
        public void MarkTaskCompletedFlow_Should_Mark_Task_As_Completed()
        {
            // Arrange: create a task and inject test I/O
            var fakeStorage = new FakeInMemoryStorage();
            var repo = new TodoRepository(fakeStorage);
            var todo = new Todo("Test Me");
            repo.AddTodo(todo);

            // Simulate user typing the task ID + enter to continue
            var input = new StringReader($"{todo.Id}\n\n");
            var output = new StringWriter();
            var io = new UserInterface(input, output);

            // Act: run the completion flow via Menu
            Menu.MarkTaskCompletedFlow(repo, io);

            // Assert: check that task is marked as completed and correct output is shown
            Assert.True(repo.GetAllTodos().First().IsCompleted);
            string result = output.ToString();
            Assert.Contains("Completed task:", result);
            Assert.Contains(todo.Title, result);
        }
    }
}
