using System;
using System.Collections.Generic;

namespace Rainforest
{
    class Company
    {
        private int nextContainer = 0;
        public Dictionary<string, List<Warehouse>> ItemsSold { get; private set; }//string is item in warehouse / list of warehouses that contain item
        public Dictionary<string, List<Container>> ContainersNotInWarehouse { get; private set; }
        private Dictionary<string, int> UncontainedFruit = new Dictionary<string, int>();
        private
        public Company()
        {
            this.UncontainedFruit.Add("Apple", 0);
            this.UncontainedFruit.Add("Pear", 0);
            this.UncontainedFruit.Add("Banana", 0);
            this.UncontainedFruit.Add("Strawberry", 0);
        }
        private List<Warehouse> WarehousesOwned;
        //keep track of warehouses and build new warehouses

        public void Run(List<string> menu)
        {
            Display screen = new Display();
            string selection = "play";
            while (selection != "Exit")
            {
                selection = screen.Run(menu);

                if (selection == "Harvest Fruit")
                {
                    PickFruit();
                }
                if (selection == "Pack Container")
                {

                }
                if (selection == "Build Warehouse")
                {

                }
                if (selection == "Send To Warehouse")
                {

                }
                if (selection == "Find Item")
                {

                }
            }
        }
        public void PickFruit()
        {
            List<string> fruits = UncontainedFruit;
            fruits.Add("New Fruit");
            fruits.Add("Exit");
            ;
            Display screen = new Display();
            string selection = "pick";
            while (selection != "Exit")
            {
                selection = screen.Run(fruits);
                if (selection == "New Fruit")
                {
                    Console.WriteLine("Enter the name of this wonderfull new fruit:");
                    selection = (selection == "" ? "Exit" : selection);
                }
                else { }


                if (UncontainedFruit.TryGetValue(selection, out int alreadyExists))
                {
                    alreadyExists++;
                    UncontainedFruit[selection] = alreadyExists;
                }
                else
                {
                    UncontainedFruit.Add(selection, 1);
                }
            }
        }
        public void ConstructWarehouse(string city)
        {

        }

        public void ConstructContainer()
        {
            // build the container
            //add container to notInWarehouse containers
        }
        public void PackContainer(string containerID)
        {
            //put stuff in a container
        }
        public void ShipContainer(string containername)
        {
            //put container in dest warehouse
        }
    }
}