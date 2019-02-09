using System;
using System.Collections.Generic;
using System.Threading;


namespace gameboy
{
    class CheatController
    {
        public bool active { get; private set; } = false;
        private List<string> cheats = new List<string>() { "Enter Cheat", "View Active Cheats", "Disable Cheats", "Exit" };
        private string menuType = "CHEATS";
        private Display display;
        public List<string> ActiveCheats { get; private set; } = new List<string>();
        private List<string> InactiveCheats = new List<string>() { "Immortality", "Unlimited Money", "Unlocked R.P.C", "Unlocked T.T.T" };
        private List<string> CheatCodes = new List<string>() { "l1v3s", "MrBurns", "rps", "ttt" };
        public void CheatMenu()
        {
            Console.Clear();
            string userRequest = "";
            while (userRequest != "Exit")
            {
                display = new Display();
                userRequest = display.getInput(cheats, menuType);

                if (userRequest == "Enter Cheat")
                {
                    AddCheat();
                }
                if (userRequest == "View Active Cheats")
                {
                    ViewActiveCheats();
                }
                if (userRequest == "Disable Cheats")
                {
                    DisableCheat();
                }
            }

        }

        public void AddCheat()
        {
            Console.Clear();
            Console.Write("Enter Cheat Code: ");
            string checkThis = CheckCheat(Console.ReadLine());

            if (checkThis == "Invalid")
            {
                Console.Clear();
                Console.WriteLine("Invalid Code");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                string activated = ActivateCheat(checkThis);
                if (activated != "Active")
                {
                    Console.Clear();
                    Console.WriteLine("you have activated a cheat");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("This code is already active");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }


        }
        private string CheckCheat(string input)
        {
            string validate = "Invalid";

            foreach (var item in CheatCodes)
            {
                if (input == item)
                {
                    validate = input;
                    break;
                }
            }
            return validate;
        }
        private string ActivateCheat(string code)
        {
            string result = "Active";
            for (int i = 0; i < CheatCodes.Count; i++)
            {
                if (code == CheatCodes[i])
                {
                    if (ActiveCheats.Count > 0)
                    {
                        foreach (var item in ActiveCheats)
                        {
                            if (item == InactiveCheats[i])
                            {
                                break;
                            }
                            else
                            {
                                result = code;
                                ActiveCheats.Add(InactiveCheats[i]);
                                break;
                            }

                        }

                    }
                    else
                    {
                        result = code;
                        ActiveCheats.Add(InactiveCheats[i]);
                    }
                }
            }

            return result;
        }
        private void ViewActiveCheats()
        {
            Console.Clear();
            Display showCheats = new Display();
            string title = "ACTIVE CHEATS";
            showCheats.ShowData(ActiveCheats, title);
        }
        private void DisableCheat()
        {
            List<string> active = ActiveCheats;
            active.Add("Cancel");
            active.Add("Remove All");
            Display deactivateCheats = new Display();
            string userRequest = deactivateCheats.getInput(active, "DISABLE CHEATS");
            if (userRequest == "Remove All")
            {
                ActiveCheats.RemoveRange(0, ActiveCheats.Count);
                active.Remove("Remove All");
                active.Remove("Cancel");
            }
            else if (userRequest == "Cancel")
            {
                active.Remove("Cancel");
                active.Remove("Remove All");
            }
            else
            {
                ActiveCheats.Remove(userRequest);
                active.Remove("Remove All");
                active.Remove("Cancel");
            }
        }
    }
}
