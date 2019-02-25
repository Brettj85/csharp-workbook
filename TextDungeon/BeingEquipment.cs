using System;
using System.Collections.Generic;

namespace TextDungeon
{
    public class BeingEquipment
    {
        public Dictionary<string, Dictionary<string, List<int>>> Equipped = new Dictionary<string, Dictionary<string, List<int>>>();
        public IDictionary<string, List<int>> Weapons = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Armor = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Helmet = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Gloves = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Legs = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Boots = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Accessories = new Dictionary<string, List<int>>();
        public BeingEquipment()
        {
            Equipped.Add("Weapon", null);
            Equipped.Add("Armor", null);
            Equipped.Add("Helmet", null);
            Equipped.Add("Gloves", null);
            Equipped.Add("Legs", null);
            Equipped.Add("Boots", null);
            Equipped.Add("Ring", null);
            Equipped.Add("Earing", null);
        }
        public void Add(IDictionary<string, List<int>> addMe)
        {
            foreach (var item in addMe)
            {
                switch (item.Value[0])
                {
                    case 0:
                        Weapons.Add(item);
                        break;
                    case 1:
                        Armor.Add(item);
                        break;
                    case 2:
                        Helmet.Add(item);
                        break;
                    case 3:
                        Gloves.Add(item);
                        break;
                    case 4:
                        Legs.Add(item);
                        break;
                    case 5:
                        Boots.Add(item);
                        break;
                    case 6:
                        Accessories.Add(item);
                        break;
                    default:
                        //catch
                        break;
                }
            }
        }
        public void Remove(Dictionary<string, List<int>> RemoveMe)
        {
            foreach (var item in RemoveMe)
            {
                switch (item.Value[0])
                {
                    case 0:
                        Weapons.Remove(item);
                        break;
                    case 1:
                        Armor.Remove(item);
                        break;
                    case 2:
                        Helmet.Remove(item);
                        break;
                    case 3:
                        Gloves.Remove(item);
                        break;
                    case 4:
                        Legs.Remove(item);
                        break;
                    case 5:
                        Boots.Remove(item);
                        break;
                    case 6:
                        Accessories.Remove(item);
                        break;
                    default:
                        //catch
                        break;
                }
            }
        }
        public void Equip(Dictionary<string, List<int>> AddMe)
        {
            Remove(AddMe);
            foreach (var item in AddMe)
            {
                switch (item.Value[0])
                {
                    case 0:
                        Equipped["Weapon"] = AddMe;
                        break;
                    case 1:
                        Equipped["Armor"] = AddMe;
                        break;
                    case 2:
                        Equipped["Helmet"] = AddMe;
                        break;
                    case 3:
                        Equipped["Legs"] = AddMe;
                        break;
                    case 4:
                        Equipped["Gloves"] = AddMe;
                        break;
                    case 5:
                        Equipped["Boots"] = AddMe;
                        break;
                    case 6:
                        Equipped["Ring"] = AddMe;
                        break;
                    case 7:
                        Equipped["Earing"] = AddMe;
                        break;
                    default:
                        Add(AddMe);
                        break;
                }
            }
        }
        public void UnEquip(Dictionary<string, List<int>> RemoveMe)
        {
            Add(RemoveMe);
            foreach (var item in RemoveMe)
            {
                switch (item.Value[0])
                {
                    case 0:
                        Equipped["Weapon"] = null;
                        break;
                    case 1:
                        Equipped["Armor"] = null;
                        break;
                    case 2:
                        Equipped["Helmet"] = null;
                        break;
                    case 3:
                        Equipped["Legs"] = null;
                        break;
                    case 4:
                        Equipped["Gloves"] = null;
                        break;
                    case 5:
                        Equipped["Boots"] = null;
                        break;
                    case 6:
                        Equipped["Ring"] = null;
                        break;
                    case 7:
                        Equipped["Earing"] = null;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}