using Microsoft.EntityFrameworkCore;
using todo_asp_mvc.Models;
namespace todo_asp_mvc.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }

        public void RetriveObjectByID(int id, out Todo? item)
        {
            item = Todo.FirstOrDefault(item => item.Id == id);
        }
    }
}
