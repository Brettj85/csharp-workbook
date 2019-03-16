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

            while (true)
            {
                //make a choice and loop while the choice is invalid
                Console.Write("c.r.u.d (or e for exit): ");
                string request = Console.ReadLine();
                if (request == "e")
                {
                    break;
                }
                switch (request)
                {
                    case "c":
                        break;
                    case "r":
                        break;
                    case "u":
                        break;
                    case "d":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection.");
                        Thread.Sleep(500);
                        Console.Clear();
                        break;
                }
            }
        }
        static void CreateItem()
        {
            ToDoDBContext context = new ToDoDBContext(opts);
            context.Database.EnsureCreated();
            ToDo entry = new ToDo();
            Console.Clear();
            Console.Write("Enter a title");
            entry.Title = Console.ReadLine();
            Console.Write("Enter Reminder");
            entry.Content = Console.ReadLine();
            entry.CreateDate = DateTime.Now;

            context.ToDos.Add(entry);
        }
    }
}