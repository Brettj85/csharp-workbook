using System;
using System.Collections.Generic;


namespace gameboy
{
    class ProfileController
    {
        public bool active { get; private set; } = true;//bypass profile with true
        private string firstName = "";
        private string lastName = "";
        private List<string> profileOptions = new List<string>() { "Game Stats", "Change Name", "Exit" };
        private string menuType = "PROFILE";

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
        private Display display;
        public void ProfileMenu()
        {
            string userRequest = "";
            while (userRequest != "Exit")
            {
                display = new Display();
                userRequest = display.getInput(profileOptions, menuType);
            }
        }
    }
}