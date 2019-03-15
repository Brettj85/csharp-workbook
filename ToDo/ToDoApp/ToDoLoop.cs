using System;
using System.Collections.Generic;
using ToDoApp.Display;

namespace ToDoApp
{
    internal class ToDoLoop
    {
        ToDoDbContext DataBase;

        public ToDoLoop(ToDoDbContext db)
        {
            DataBase = db;
        }

        public void Run()
        {
            string request = "";
            while (true)
            {
                while (request != "" && request != "a" && request != "d" && request != "v" && request != "e")
                {
                    List<string> options = new List<string> { "Add Entry", "Update Entry", "Delete Entry", "View Entry", "Exit" };
                    DisplayVertical display = new DisplayVertical(options, 0);


                    if (request == "e")
                    {
                        break;
                    }

                    ModifyTask task = new ModifyTask();
                    switch (request)
                    {
                        case "a":
                            task.AddTask(0, DataBase);
                            break;
                        case "u":
                            task.UpdateTask(0, DataBase);
                            break;
                        case "d":
                            task.RemoveTask(0, DataBase);
                            break;
                        case "v":
                            task.ViewTask(0, DataBase);
                            break;
                        default:
                            break;
                    }
                }
                if (request == "e")
                {
                    break;
                }
            }//finish them
        }
    }
}