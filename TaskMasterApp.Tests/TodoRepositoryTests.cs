using System;
using System.IO;
using System.Linq;
using TaskMasterApp.Models;
using TaskMasterApp.Services;
using TaskMasterApp.UI;           // 👈 For Menu and UserInterface
using Xunit;


namespace TaskMasterApp.Tests
{
    public class TodoRepositoryTests
    {
        [Fact]
        public void AddTodo_Should_Add_To_List()
        {
            // Arrange
            var fakeStorage = new FakeInMemoryStorage();
            var repo = new TodoRepository(fakeStorage);
            var todo = new Todo("Test Todo");

            // Act
            repo.AddTodo(todo);
            var todos = repo.GetAllTodos();

            // Assert
            Assert.Single(todos);
            Assert.Equal("Test Todo", todos.First().Title);
        }



    }
}