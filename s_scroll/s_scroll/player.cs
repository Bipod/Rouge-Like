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

        private Texture2D texture;

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
            texture = conMan.Load<Texture2D>(name);
            position.X = (SCREEN_WIDTH / 2) / 32;
            position.Y = (SCREEN_HEIGHT / 2) / 32;
        }

        public void Draw(SpriteBatch sprBat)
        {
            grid.MoveSpriteToGrid(sprBat, texture, old_position.X, old_position.Y, position.X, position.Y);
        }

        public void Update()
        {
            KeyboardState cur_state = Keyboard.GetState();
            Move(cur_state);
        }

        public void Move(KeyboardState cur_state)
        {
            old_position = position;

            if (old_state.IsKeyUp(Keys.W) && cur_state.IsKeyDown(Keys.W) && !grid.IsGridSpotFull(position.X, position.Y - 1))
                position.Y--;
            else if (old_state.IsKeyUp(Keys.A) && cur_state.IsKeyDown(Keys.A) && !grid.IsGridSpotFull(position.X - 1, position.Y))
                position.X--;
            if (old_state.IsKeyUp(Keys.S) && cur_state.IsKeyDown(Keys.S) && !grid.IsGridSpotFull(position.X, position.Y + 1))
                position.Y++;
            else if (old_state.IsKeyUp(Keys.D) && cur_state.IsKeyDown(Keys.D) && !grid.IsGridSpotFull(position.X + 1, position.Y))
                position.X++;

            old_state = cur_state;
        }

    }
}
