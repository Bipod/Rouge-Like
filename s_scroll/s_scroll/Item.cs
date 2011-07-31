using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace r_like
{
    class Item
    {

        private string name = "";

        public Item(string item_name)
        {
            name = item_name;
        }

        public string GetName()
        {
            return name;
        }

        public virtual void Use()
        {
        }

    }
}
