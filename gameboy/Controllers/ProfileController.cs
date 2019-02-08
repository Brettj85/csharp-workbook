using System;
using System.Collections.Generic;
using System.Threading;

namespace gameboy
{
    class ProfileController
    {
        public bool active { get; private set; } = false;
        private string firstName = "";
        private string lastName = "";
        private List<string> profileOptions = new List<string>() { "Game Stats", "Change Name", "Exit" };

        public void Create()
        {
            do
            {
                if (firstName == "")
                {
                    Console.Write("Enter first name: ");
                    this.firstName = Console.ReadLine();
                }
                if (lastName == "")
                {
                    Console.Write("Enter last name: ");
                    this.lastName = Console.ReadLine();
                }
                Console.Clear();
            } while (firstName == "" || lastName == "");
            this.active = true;
        }
        private Display display = new Display();
        public void ProfileMenu()
        {
            string userRequest = display.getInput(profileOptions);
        }
    }
}