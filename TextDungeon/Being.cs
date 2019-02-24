using System;
using System.Collections.Generic;

namespace TextDungeon
{
    public abstract class Being
    {
        public int level { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Health { get; private set; }
        public List<int> stats { get; private set; }
        public List<string> Items { get; private set; }
        public abstract int Attack();
        public abstract int SpecialOne();
        public abstract int SpecialTwo();
        public abstract int SpecialThree();
        private void SetInitialStats(int level, string monsterType)
        {
            BeingTypes basetype = new BeingTypes();
            List<int> baseAbility = basetype.ReturnRaceAttributes(Type);
        }
    }
}
