using Microsoft.EntityFrameworkCore;
using System;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NewDatabase newToDoDb = new NewDatabase();

            ToDoLoop toDoLoop = new ToDoLoop(newToDoDb.GetDb());
            toDoLoop.Run();

            //stop program from closing
            Console.ReadLine();
        }
    }
}
