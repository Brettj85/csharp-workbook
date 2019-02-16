using System;

namespace gameboy
{
    class PlayerProfile
    {
        public string Handle { get; private set; }
        public string PlayerName { get; private set; }
        public PlayerProfile()
        {
            this.gameData = null;
            this.Handle = null;
            this.PlayerName = null;
        }
        public void setHandle()
        {
            Console.Write("Enter new Handle :");
            string userInput = Console.ReadLine();
            this.Handle = userInput == "" ? "Player Unknown" : userInput;
        }
        public void setName()
        {
            Console.Write("Enter First Name :");
            string userInput = Console.ReadLine();
            string first = userInput == "" ? "Unknown" : userInput;
            Console.Write("Enter First Name :");
            userInput = Console.ReadLine();
            string last = userInput == "" ? "Unknown" : userInput;
            PlayerName = first + " " + last;
        }
    }
}