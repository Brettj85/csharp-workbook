using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace SimplifiedTodo
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<ToDoDBContext> builder = new DbContextOptionsBuilder<ToDoDBContext>();
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=ToDoDB;Trusted_Connection=true");
            DbContextOptions<ToDoDBContext> opts = builder.Options;
            ToDoDBContext context = new ToDoDBContext(opts);
            context.Database.EnsureCreated();

            Crud crud = new Crud(context);
            crud.Run();
        }
    }
}