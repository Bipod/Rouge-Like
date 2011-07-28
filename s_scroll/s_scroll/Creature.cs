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

        const int SCREEN_WIDTH = 800;
        const int SCREEN_HEIGHT = 800;

        private Texture2D texture_sheet;
        private Rectangle src_rect = new Rectangle(0, 0, 32, 32);
        private Grid grid;
        private Random rand = new Random();
        struct grid_position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        grid_position position;
        grid_position old_position;

        public Creature(Grid g)
        {
            grid = g;
            //position.X = rand.Next(0, SCREEN_WIDTH / 32);
            //position.Y = rand.Next(0, SCREEN_HEIGHT / 32);
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

        public void Update()
        {
            old_position = position;
            int r = rand.Next() % 4;
            if (r == 0 && !grid.IsGridSpotFull(position.X + 1, position.Y))
            {
                position.X++;
            }
            else if (r == 1 && !grid.IsGridSpotFull(position.X - 1, position.Y))
            {
                position.X--;
            }
            else if (r == 2 && !grid.IsGridSpotFull(position.X, position.Y + 1))
            {
                position.Y++;
            }
            else if (r == 3 && !grid.IsGridSpotFull(position.X, position.Y - 1))
            {
                position.Y--;
            }
            
        }

    }
}
