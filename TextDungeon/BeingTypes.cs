using System;
using System.Collections.Generic;

namespace TextDungeon
{
    class BeingTypes
    {

        private Dictionary<string, List<int>> Type = new Dictionary<string, List<int>>();

        //(str, int, armor modifier, resistances - fire, ice, earth, air, light, dark)
        public BeingTypes()
        {
            Type.Add("Insect", new List<int> { 2, 0, 5, 3, -2, -4, -4, 0, 0 });
            Type.Add("Dragon", new List<int> { 7, 7, 7, -7, -7, -7, -7, 7, 7 });
            /*dragon gets resistance for 1 or 2 but also lowers opposing the same amount: 
            fire-ice, earth-air or combonation of up to 2 @ 50% each or 1 at 100% dmg reduction/ opposing increase*/
            Type.Add("orc", new List<int> { 5, -4, 3, 2, 2, 2, 2, 2, -2 });
            Type.Add("Human", new List<int> { 2, 2, 0, 0, 0, 0, 0, 0, 0 });
            Type.Add("Elf", new List<int> { 0, 4, 0, -2, -2, -2, -2, -2, 2 });
            Type.Add("goblin", new List<int> { -5, 5, 0, 0, 0, 0, 0, 5, -5 });
            Type.Add("troll", new List<int> { 7, -5, 6, 3, 3, 3, 3, 10, 0 });
            Type.Add("Centar", new List<int> { 7, -5, 6, 3, 3, 3, 3, 0, 10 });
            Type.Add("Beast", new List<int> { 2, 0, 0, 3, -2, -2, -2, 2, 2 });
            Type.Add("special", new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        }
        public List<int> ReturnRaceAttributes(string request)
        {
            List<int> type = Type[request];
            return type;
        }
    }
}