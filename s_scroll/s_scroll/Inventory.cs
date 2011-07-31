using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace r_like
{
    class Inventory
    {

        Player player;

        public struct item_in_list
        {
            public Item item;
            public int amount;
        }

        private List<item_in_list> inventory = new List<item_in_list>();

        public void AddToInventory(Item item, int amt)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].item.GetName() == item.GetName())
                {
                    amt += inventory[i].amount;
                    inventory.RemoveAt(i);
                    break;
                }
            }

            item_in_list t;
            t.item = item;
            t.amount = amt;
            inventory.Add(t);
        }

        public void RemoveFromInventory(Item item, int amt)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].item.GetName() == item.GetName())
                    amt = inventory[i].amount - amt;
                if (amt == 0)
                    inventory.RemoveAt(i);
            }
            item_in_list t;
            t.item = item;
            t.amount = amt;
            inventory.Add(t);
        }

        public bool Use(int index)
        {
            if (index < inventory.Capacity)
            {
                inventory[index].item.Use();
                return true;
            }
            else
                return false;
        }

        public void SetPlayer(Player pl)
        {
            player = pl;
        }

    }
}
