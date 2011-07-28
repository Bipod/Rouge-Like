using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace r_like
{
    class Creature
    {
        //
        //
        //ADD THE A* PART IN, IT'S NOT DONE YET.
        //
        //


        const int SCREEN_WIDTH = 800;
        const int SCREEN_HEIGHT = 800;

        private Texture2D texture_sheet;
        private Rectangle src_rect = new Rectangle(0, 0, 32, 32);
        private Grid grid;
        private Random rand = new Random();

        public struct grid_position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        grid_position position;
        grid_position old_position;

        public Creature(Grid g)
        {
            grid = g;
            position.X = 5;
            position.Y = 5;
        }

        public void LoadTexture(ContentManager conMan, string name)
        {            
            texture_sheet = conMan.Load<Texture2D>(name);
        }

        public void Draw(SpriteBatch sprBat)
        {
            grid.MoveSpriteToGrid(sprBat, texture_sheet, src_rect, old_position.X, old_position.Y, position.X, position.Y);
        }

        public void Update(Player player)
        {
            old_position = position;
            int r = rand.Next(0, 2);
            int r2;

            if (r == 0)
            {
                r2 = player.position.X - position.X;
                bool is_straight_line = false;
                if (r2 == 0)
                    is_straight_line = true;

                if (!is_straight_line)
                    r2 = Math.Sign(r2);
                if (!grid.IsGridSpotFull(position.X + r2, position.Y) && !is_straight_line)
                    position.X += r2;
                else if (!grid.IsGridSpotFull(position.X, position.Y + r2))
                    position.Y += r2;
            }
            else
            {
                r2 = player.position.Y - position.Y;
                bool is_straight_line = false;
                if (r2 == 0)
                    is_straight_line = true;

                if(!is_straight_line)
                    r2 = Math.Sign(r2);
                if (!grid.IsGridSpotFull(position.X, position.Y + r2) && !is_straight_line)
                    position.Y += r2;
                else if (!grid.IsGridSpotFull(position.X + r2, position.Y))
                    position.X += r2;
            }
            
        } //Update

    }
}
