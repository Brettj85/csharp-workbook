using System;
using System.Threading;

namespace SimplifiedTodo
{
    internal class Crud
    {
        private static ToDoDBContext Context;

        public Crud(ToDoDBContext c)
        {
            Context = c;
        }
        public void Run()
        {
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
                        CreateItem();
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
        public static void CreateItem()
        {
            ToDo entry = new ToDo();
            Console.Clear();
            Console.Write("Enter a title");
            entry.Title = Console.ReadLine();
            Console.Write("Enter Reminder");
            entry.Content = Console.ReadLine();
            entry.CreateDate = DateTime.Now;
            Context.ToDos.Add(entry);
            Context.SaveChanges();
        }
        public static void ReadItem()
        {
            string input = "";
            while (input == "")
            {
                Console.Clear();
                Console.WriteLine("Enter an id or a range of id's seperated by a \"-\" (example \"1-7\")");
                Console.Write(": ");
                input = Console.ReadLine();

                if (input == "")
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Entry");
                    Thread.Sleep(500);
                }

                if (!input.Contains("-") || !int.TryParse(input, out int num))
                {
                    input = "";
                    Console.Clear();
                    Console.WriteLine("Invalid Entry");
                    Thread.Sleep(500);
                }
            }
            ToDo entry;
            if (input.Contains("-"))
            {
                Console.WriteLine("This functionality is under construction");
            }
            else
            {
                entry = Context.ToDos.Find(input);
                Console.WriteLine("*****************************************************************************************************************");
                Console.Write("Title: ");
                Console.WriteLine(entry.Title);
                Console.Write("Created: ");
                Console.WriteLine(entry.CreateDate);
                Console.Write("Content: ");
                Console.WriteLine(entry.Content);
                if (entry.Completed)
                {
                    if (entry.Sucess)
                    {
                        Console.WriteLine("Status: Completed Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Status: Abandoned");
                    }
                }
                else
                {
                    Console.WriteLine("Status: In Progress");
                }
                Console.WriteLine("*****************************************************************************************************************");
                Console.ReadLine();
            }

        }
        public static void UpdateItem()
        {
            string input = "";
            while (input == "")
            {
                Console.Write("Enter item Id: ");
                Console.Clear();
                input = Console.ReadLine();
            }
            var find = Context.ToDos.Find(input);
            if (find != null)
            {
                string modifyWhat = "";
                while (modifyWhat != "t" || modifyWhat != "c" || modifyWhat != "s" || modifyWhat != "a" || modifyWhat != "e")
                {
                    Console.WriteLine("*****************************************************************************************************************");
                    Console.Write("Title: ");
                    Console.WriteLine(find.Title);
                    Console.Write("Created: ");
                    Console.WriteLine(find.CreateDate);
                    Console.Write("Content: ");
                    Console.WriteLine(find.Content);
                    Console.WriteLine("*****************************************************************************************************************");
                    Console.WriteLine();
                    Console.Write("Modify Entry");
                    Console.Write("t = Title c = Content s = successful a = abandon e = Exit: ");
                    Console.ReadLine();
                }
                if (modifyWhat == "t")
                {
                    string userInput = "";
                    while (userInput != "")
                    {
                        Console.Clear();
                        Console.Write("Enter new Title: ");
                        userInput = Console.ReadLine();
                    }
                    find.Title = userInput;
                }
                else if (modifyWhat == "c")
                {
                    string userInput = "";
                    while (userInput != "")
                    {
                        Console.Clear();
                        Console.Write("Enter new Content: ");
                        userInput = Console.ReadLine();
                    }

                    find.Content = userInput;
                }
                else if (modifyWhat == "s")
                {
                    find.Completed = true;
                }
                else if (modifyWhat == "a")
                {
                    find.Completed = true;
                    find.Sucess = false;
                }
                Context.SaveChanges();
            }
        }
        public static void DeleteItem()
        {

        }
    }
}
