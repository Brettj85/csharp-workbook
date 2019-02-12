using System;
using System.Collections.Generic;
namespace Rainforest
{
    class Program
    {

        static void Main(string[] args)
        {

            List<string> menuItems = new List<string>() { "Harvest Fruit", "Pack Container", "Build Warehouse", "Send To Warehouse", "Find Item", "Exit" };
            Company bod = new Company();
            bod.Run(menuItems);
        }
    }
}
