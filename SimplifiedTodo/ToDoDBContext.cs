using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedTodo
{
    public class ToDoDBContext : DbContext
    {
        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) : base(options)
        {

        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}

