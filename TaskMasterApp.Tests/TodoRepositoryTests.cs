using System;
using System.Linq;
using TaskMasterApp.Models;
using TaskMasterApp.Services;
using Xunit;

namespace TaskMasterApp.Tests
{
    public class TodoRepositoryTests
    {
        [Fact]
        public void AddTodo_Should_Add_To_List()
        {
            // Arrange
            var repo = new TodoRepository();
            var todo = new Todo("Test Todo");

            // Act
            repo.AddTodo(todo);
            var todos = repo.GetAllTodos();

            // Assert
            Assert.Single(todos);
            Assert.Equal("Test Todo", todos.First().Title);
        }

        [Fact]
        public void MarkTodoAsCompleted_Should_Set_IsCompleted_To_True()
        {
            // Arrange
            var repo = new TodoRepository();
            var todo = new Todo("Complete me");
            repo.AddTodo(todo);

            // Act
            repo.MarkTodoAsCompleted(todo.Id);

            // Assert
            Assert.True(repo.GetAllTodos().First().IsCompleted);
        }

    }
}