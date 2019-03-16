using Microsoft.EntityFrameworkCore;

namespace ToDoApp
{
    internal class NewDatabase
    {
        ToDoDbContext Context;

        public void CreateTheDB()
        {
            DbContextOptionsBuilder<ToDoDbContext> builder = new DbContextOptionsBuilder<ToDoDbContext>();
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=BlogDB;Trusted_Connection=true");
            DbContextOptions<ToDoDbContext> opts = builder.Options;
            ToDoDbContext context = new ToDoDbContext(opts);
            Context = context;
        }
        public ToDoDbContext GetDb()
        {
            return Context;
        }
    }
}