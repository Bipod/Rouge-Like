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
    class TeleportWand : Item
    {

        Texture2D texture;
        Grid grid;
        Player player;
        Creature.grid_position position;

        bool is_picked_up;

        public TeleportWand(Grid g, Creature.grid_position pos, Player pl)
            : base("teleport_wand")
        {
            grid = g;
            position = pos;
            player = pl;
            is_picked_up = false;
        }

        public void LoadTexture(ContentManager con_man, string name)
        {
            texture = con_man.Load<Texture2D>(name);
        }

        private void SetAtPosition(SpriteBatch sprBat)
        {
            grid.DrawSpriteOnGrid(sprBat, texture, position.X, position.Y, false);
        }

        public void Update()
        {
            if (!is_picked_up)
            {
                if (position.X == player.position.X && position.Y == player.position.Y)
                    is_picked_up = true;
                player.inventory.AddToInventory(this, 1);
            }
        }

        public void Draw(SpriteBatch sprBat)
        {
            if (!is_picked_up)
            {
                grid.DrawSpriteOnGrid(sprBat, texture, position.X, position.Y, true);
            }
        }

        public override void Use()
        {
            Random rand = new Random();
            Creature.grid_position start_position = player.position;
            int x_modifier = rand.Next(-4, 4);
            int y_modifier = rand.Next(-4, 4);

            while (true)
            {
                if (start_position.X + x_modifier < 0 || start_position.Y + y_modifier < 0
                    || grid.IsGridSpotFull(start_position.X + x_modifier, start_position.Y + y_modifier))
                {
                    x_modifier = rand.Next(-4, 4);
                    y_modifier = rand.Next(-4, 4);
                }

                else
                    break;
            }

            player.inventory.RemoveFromInventory(this, 1);

            start_position.X += x_modifier;
            start_position.Y += y_modifier;
            player.position = start_position;
        }

    }
}
