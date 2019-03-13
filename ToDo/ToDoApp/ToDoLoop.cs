using System;

namespace ToDoApp
{
    internal class ToDoLoop
    {
        public void Run()
        {
            string request = "";
            while (true)
            {
                while (request == "" && request != "a" && request != "d" && request != "v" && request != "e")
                {
                    //Display.Menu.Main();
                }

                if (request == "e")
                {
                    break;
                }
                var task = new DisplayTask();
                switch (request)
                {
                    case "a":
                        task.AddTask();
                        break;
                    case "u":
                        task.UpdateTask();
                        break;
                    case "d":
                        task.RemoveTask();
                        break;
                    case "v":
                        task.ViewTask();
                        break;
                    default:
                        break;
                }
                if (request != "e")
                {
                    break;
                }
                else if (request != "a")
                {
                    AddEntry addtask = new AddEntry();
                    addtask.NewTask();
                }
                else if (request != "d")
                {
                    DeleteEntry remtask = new DeleteEntry();
                    remtask.RemoveTask();
                }
                else if (request != "v")
                {
                    DeleteEntry remtask = new DeleteEntry();
                    remtask.RemoveTask();
                }
            }//finish them
        }
    }
}