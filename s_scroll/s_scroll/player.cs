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
    class Player
    {

        const int SCREEN_WIDTH = 800;
        const int SCREEN_HEIGHT = 800;

        private Texture2D texture_sheet;
        private Rectangle src_rect = new Rectangle(0, 0, 32, 32);
        private float cur_time = 0;
        private float old_time;

        struct grid_position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        grid_position position;
        grid_position old_position;
        private KeyboardState old_state;
        Grid grid;

        public Player(Grid g)
        {
            grid = g;
        }

        public void LoadTexture(ContentManager conMan, string name)
        {
            texture_sheet = conMan.Load<Texture2D>(name);
            position.X = (SCREEN_WIDTH / 2) / 32;
            position.Y = (SCREEN_HEIGHT / 2) / 32;
        }

        public void Draw(SpriteBatch sprBat)
        {
            grid.MoveSpriteToGrid(sprBat, texture_sheet, src_rect, old_position.X, old_position.Y, position.X, position.Y);
        }

        public bool Update()
        {
            KeyboardState cur_state = Keyboard.GetState();
            return Move(cur_state);
        }

        public bool Move(KeyboardState cur_state)
        {
            old_position = position;

            if (cur_time - old_time > 7 && cur_state.IsKeyDown(Keys.W) && !grid.IsGridSpotFull(position.X, position.Y - 1))
            {
                position.Y--;
                src_rect = new Rectangle(32, 32, 32, 32);
                cur_time = 0;
                old_time = 0;
                return true;
            }
            else if (cur_time - old_time > 7 && cur_state.IsKeyDown(Keys.A) && !grid.IsGridSpotFull(position.X - 1, position.Y))
            {
                position.X--;
                src_rect = new Rectangle(32, 0, 32, 32);
                cur_time = 0;
                old_time = 0;
                return true;
            }
            if (cur_time - old_time > 7 && cur_state.IsKeyDown(Keys.S) && !grid.IsGridSpotFull(position.X, position.Y + 1))
            {
                position.Y++;
                src_rect = new Rectangle(0, 32, 32, 32);
                cur_time = 0;
                old_time = 0;
                return true;
            }
            else if (cur_time - old_time > 7 && cur_state.IsKeyDown(Keys.D) && !grid.IsGridSpotFull(position.X + 1, position.Y))
            {
                position.X++;
                src_rect = new Rectangle(0, 0, 32, 32);
                cur_time = 0;
                old_time = 0;
                return true;
            }
            cur_time += 1;
            old_state = cur_state;
            return false;
        }

    }
}
