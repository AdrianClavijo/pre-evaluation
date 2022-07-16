using DevTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DevUnitTest.System.Services
{
    public class ContactService
    {
        protected readonly DB_DevTestContext _context;

        public ContactService()
        {
            _context = new DB_DevTestContext();

            _context.Database.EnsureCreated();
        }
        /*
        [Fact]
        public async Task GetAllAsync_ReturnTodoCollection()
        {
            
            /// Arrange
            _context.Todo.AddRange(MockData.TodoMockData.GetTodos());
            _context.SaveChanges();

            var sut = new TodoService(_context);

            /// Act
            var result = await sut.GetAllAsync();

            /// Assert
            result.Should().HaveCount(TodoMockData.GetTodos().Count);
            
        }
        */
    }
}
