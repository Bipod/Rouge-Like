using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace r_like
{

    class Grid
    {

        #region Variables

        private Texture2D texture;
        const int SCREEN_WIDTH = 800;
        const int SCREEN_HEIGHT = 800;
        const int GRID_WIDTH = SCREEN_WIDTH / 32;
        const int GRID_HEIGHT = SCREEN_HEIGHT / 32;

        private bool[] grid_spot_is_full = new bool[SCREEN_WIDTH * SCREEN_HEIGHT / 1024];   //1024 is pow(32, 2)

        #endregion

        #region Methods

        public void LoadTexture(ContentManager conMan, string name)
        {
            texture = conMan.Load<Texture2D>(name);
            for (int i = 0; i < grid_spot_is_full.Length; i++)
            {
                grid_spot_is_full[i] = false;
            }
        }

        public void DrawGrid(SpriteBatch sprBat)
        {
            for (int i = 0; i < SCREEN_WIDTH; i += 32)
            {
                for (int j = 0; j < SCREEN_HEIGHT; j += 32)
                {
                    sprBat.Draw(texture, new Rectangle(i, j, 32, 32), Color.White);
                }
            }
        }

        public void DrawSpriteOnGrid(SpriteBatch sprBat, Texture2D texture, Rectangle source, int x, int y, bool is_already_on)
        {
            if (!is_already_on)
                AddToGrid(x, y);
            sprBat.Draw(texture, new Vector2(x * 32, y * 32), source, Color.White);
        }
        public void DrawSpriteOnGrid(SpriteBatch sprBat, Texture2D texture, int x, int y, bool is_already_on)
        {
            if(!is_already_on)
                AddToGrid(x, y);
            sprBat.Draw(texture, new Rectangle(x * 32, y * 32, texture.Width, texture.Height), Color.White);
        }

        public void MoveSpriteToGrid(SpriteBatch sprBat, Texture2D texture, int old_x, int old_y, int new_x, int new_y)
        {
            MoveOnGrid(old_x, old_y, new_x, new_y);
            sprBat.Draw(texture, new Rectangle(new_x * 32, new_y * 32, texture.Width, texture.Height), Color.White);
        }
        public void MoveSpriteToGrid(SpriteBatch sprBat, Texture2D texture, Rectangle source, int old_x, int old_y, int new_x, int new_y)
        {
            MoveOnGrid(old_x, old_y, new_x, new_y);
            sprBat.Draw(texture, new Vector2(new_x * 32, new_y * 32), source, Color.White);
        }

        public bool IsGridSpotFull(int x, int y)
        {
            return grid_spot_is_full[x + (y * GRID_WIDTH)];
        }

        private void MoveOnGrid(int old_x, int old_y, int new_x, int new_y)
        {
            grid_spot_is_full[old_x + (old_y * GRID_WIDTH)] = false;
            grid_spot_is_full[new_x + (new_y * GRID_WIDTH)] = true;
        }

        private void AddToGrid(int x, int y)
        {
            grid_spot_is_full[x + (y * GRID_WIDTH)] = true;
        }

    }
}

        #endregion