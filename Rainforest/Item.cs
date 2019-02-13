using System;
using System.Collections.Generic;

namespace Rainforest
{
    class Item
    {
        public string Name { get; private set; }
        Dictionary<List<string>, List<string>> locations = new Dictionary<List<string>, List<string>>();
        public Item(string name)
        {
            this.Name = name;
        }

    }
}