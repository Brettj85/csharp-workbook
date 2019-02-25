using System;
using System.Collections.Generic;

namespace TextDungeon
{
    public abstract class Being
    {
        public int level { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public List<int> Stats { get; private set; }
        public BeingEquipment Equipment { get; private set; }
        public BeingAbility Ability { get; private set; }
        public abstract int AttackOne();
        public abstract int AttackTwo();
        public abstract int AttackThree();
        private void SetStats(int level, string monsterType)
        {
            BeingTypes basetype = new BeingTypes();
            Stats = basetype.ReturnRaceAttributes(Type);
        }
        public int Melee()
        {
            Ability.Melee();
        }
        public int Magic()
        {
            Ability.Magic();
        }
        public int Utility()
        {
            Ability.Utility();
        }
    }
}


// ╠
// ║╔══╗  ║
// ╠╝  ║  ║
//╔╬══╦╩══╣
//╚╣  ║   ║
// ╝
//⚫◯
