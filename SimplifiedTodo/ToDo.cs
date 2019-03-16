using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifiedTodo
{
    public class ToDo
    {
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public bool Sucess { get; set; } = true;
        public int Id { get; set; }
    }
}
