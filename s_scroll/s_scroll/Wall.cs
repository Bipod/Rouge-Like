using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace r_like
{
    class Wall
    {

        const int TEXTURE_WIDTH = 32;
        const int TEXTURE_HEIGHT = 32;

        // U(p) D(own) L(eft) R(ight) connections at that tile
        // Straight Pieces
        // 1.) LR
        // 2.) UD

        // Corners
        // 3.) DR
        // 4.) DL
        // 5.) UR
        // 6.) UL

        // Three-way intersection
        // 7.) UDR
        // 8.) UDL
        // 9.) ULR
        // 10.) DLR

        // All four
        // 11.) UDLR
        Rectangle[] textures = new Rectangle[11];
        
        private Texture2D texture_sheet;
        public Vector2 position;
        private Grid grid;

        public Wall(Grid g)
        {
            int is_zero = 0;
            for (int i = 0; i < 11; i++)
            {
                textures[i] = new Rectangle(is_zero, i % 2 == 0 || i == 0 ? i * 16 : (i - 1) * 16, TEXTURE_WIDTH, TEXTURE_HEIGHT);
                // new Rectangle(either 0 or 32, i * 32 i is even, (i - 1) * 32 if it's odd (to get the right number), 32, 32)

                is_zero = is_zero == 32 ? 0 : 32;
            }

            grid = g;

        }

        public void LoadTexture(ContentManager conMan, string name)
        {
            texture_sheet = conMan.Load<Texture2D>(name);
        }

        public void Draw(SpriteBatch sprBat, int x, int y, int type)
        {
            grid.AddSpriteToGrid(sprBat, texture_sheet, textures[type], x, y);

            position = new Vector2(x, y);
        }

    }
}
