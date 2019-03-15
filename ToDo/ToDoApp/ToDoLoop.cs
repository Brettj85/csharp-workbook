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
            int index = 0;
            while (true)
            {
                while (request != "" || request != "a" || request != "d" || request != "v" || request != "e")
                {
                    List<string> options = new List<string> { "Add Entry", "Update Entry", "Delete Entry", "View Entry", "Exit" };
                    DisplayVertical display = new DisplayVertical(options, index);
                    request = display.SelectTask();


                    if (request == "e")
                    {
                        break;
                    }

                    ModifyTask task = new ModifyTask();
                    switch (request)
                    {
                        case "a":
                            index = 0;
                            task.AddTask(index, DataBase);
                            break;
                        case "u":
                            index = 0;
                            task.UpdateTask(index, DataBase);
                            break;
                        case "d":
                            index = 0;
                            task.RemoveTask(index, DataBase);
                            break;
                        case "v":
                            index = 0;
                            task.ViewTask(index, DataBase);
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