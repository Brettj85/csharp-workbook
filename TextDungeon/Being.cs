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
        public abstract int SpecialOne();
        public abstract int SpecialTwo();
        public abstract int SpecialThree();
        private void SetStats(int level, string monsterType)
        {
            BeingTypes basetype = new BeingTypes();
            Stats = basetype.ReturnRaceAttributes(Type);
        }
        public int Attack()
        {
            return Stats[0];
        }
    }
}
