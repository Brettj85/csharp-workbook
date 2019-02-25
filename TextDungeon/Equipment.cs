using System;
using System.Collections.Generic;

namespace TextDungeon
{
    class Equipment
    {
        public IDictionary<string, List<int>> Armor = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Helmet = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Gloves = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Legs = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Boots = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Weapons = new Dictionary<string, List<int>>()
                                            {
                                                /*(type, dmg, Element, int, str, armor, enchantment 1, enchantment 2 )
                                                                                   { T, D, E, I, S, A, E, E }*/
                                                {"Wooden Sword",      new List<int>{ 0, 10, 0, 0, 0, 0, 0, 0 }},
                                                {"Bronze Sword",      new List<int>{ 0, 20, 0, 0, 0, 0, 0, 0 }},
                                                {"Iron Sword",        new List<int>{ 0, 30, 0, 0, 0, 0, 0, 0 }},
                                                {"Steel Sword",       new List<int>{ 0, 40, 0, 0, 0, 0, 0, 0 }},
                                                {"Black Steel Sword", new List<int>{ 0, 50, 0, 0, 0, 0, 0, 0 }},
                                                {"Wooden Staff",      new List<int>{ 0, 5, 0, 10, 0, 0, 0, 0 }},
                                                {"Bronze Staff",      new List<int>{ 0, 10, 0, 20, 0, 0, 0, 0 }},
                                                {"Iron Staff",        new List<int>{ 0, 15, 0, 30, 0, 0, 0, 0 }},
                                                {"Steel Staff",       new List<int>{ 0, 20, 0, 40, 0, 0, 0, 0 }},
                                                {"Black Steel Staff", new List<int>{ 0, 25, 0, 50, 0, 0, 0, 0 }},
                                            };
        public IDictionary<string, List<int>> Accessories = new Dictionary<string, List<int>>()
                                            {
                                                /*(type, dmg, Element, int, str, armor, enchantment 1, enchantment 2 )
                                                                                      { T, D, E, I, S, A, E, E }*/
                                                { "Wooden Ring", new List<int>        { 6, 0, 0, 0, 5, 0, 0, 0 }},
                                                { "Bronze Ring", new List<int>        { 6, 0, 0, 0, 10, 0, 0, 0 }},
                                                { "Iron Ring", new List<int>          { 6, 0, 0, 0, 15, 0, 0, 0 }},
                                                { "Steel Ring", new List<int>         { 6, 0, 0, 0, 20, 0, 0, 0 }},
                                                { "Black Steel Ring", new List<int>   { 6, 0, 0, 0, 25, 0, 0, 0 }},
                                                { "Wooden Earing", new List<int>      { 7, 0, 0, 5, 0, 0, 0, 0 }},
                                                { "Bronze Earing", new List<int>      { 7, 0, 0, 10, 0, 0, 0, 0 }},
                                                { "Iron Earing", new List<int>        { 7, 0, 0, 15, 0, 0, 0, 0 }},
                                                { "Steel Earing", new List<int>       { 7, 0, 0, 20, 0, 0, 0, 0 }},
                                                { "Black Steel Earing", new List<int> { 7, 0, 0, 25, 0, 0, 0, 0 }},
                                            };
        public Equipment()
        {
            IDictionary<string, List<int>> Types = new Dictionary<string, List<int>>
            {
                { "Wooden Plate", new List<int> { 1, 0, 0, 0, 5, 10, 1, 0 }},
                { "Bronze Plate", new List<int> { 1, 0, 0, 0, 10, 20, 1, 0 }},
                { "Iron Plate", new List<int> { 1, 0, 0, 0, 15, 30, 1, 0 }},
                { "Steel Plate", new List<int> { 1, 0, 0, 0, 20, 40, 1, 0 }},
                { "Black Steel Plate", new List<int> { 1, 0, 0, 0, 25, 50, 1, 0 }},
                { "Cotten", new List<int> { 1, 0, 0, 5, 0, 5, 1, 0 }},
                { "Silk", new List<int> { 1, 0, 0, 10, 0, 10, 2, 0 }},
                { "Leather reinforced Cloth", new List<int> { 1, 0, 0, 15, 0, 15, 3, 0 }},
                { "Iron reinforced Cloth", new List<int> { 1, 0, 0, 20, 0, 20, 4, 0 }},
                { "Black Steel reinforced Cloth", new List<int> { 1, 0, 0, 25, 0, 25, 5, 0 }},
            };
            foreach (var item in Types)
            {
                Armor.Add(item);
                Helmet.Add(item);
                Gloves.Add(item);
                Legs.Add(item);
                Boots.Add(item);
            }
        }
    }
}
