using Microsoft.EntityFrameworkCore;
using ToDo_List_server.Models;

namespace ToDo_List_server.Data
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; } 
    }
}
