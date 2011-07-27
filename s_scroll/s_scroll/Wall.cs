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

        //static Rectangle LR = new Rectangle(0, 0, TEXTURE_WIDTH, TEXTURE_HEIGHT);         //1
        //static Rectangle UD = new Rectangle(32, 0, TEXTURE_WIDTH, TEXTURE_HEIGHT);        //2
        //static Rectangle DR = new Rectangle(0, 32, TEXTURE_WIDTH, TEXTURE_HEIGHT);        //3
        //static Rectangle DL = new Rectangle(32, 32, TEXTURE_WIDTH, TEXTURE_HEIGHT);       //4
        //static Rectangle UR = new Rectangle(0, 64, TEXTURE_WIDTH, TEXTURE_HEIGHT);        //5
        //static Rectangle UL = new Rectangle(32, 64, TEXTURE_WIDTH, TEXTURE_HEIGHT);       //6
        //static Rectangle UDR = new Rectangle(0, 96, TEXTURE_WIDTH, TEXTURE_HEIGHT);       //7
        //static Rectangle UDL = new Rectangle(32, 96, TEXTURE_WIDTH, TEXTURE_HEIGHT);      //8
        //static Rectangle ULR = new Rectangle(0, 128, TEXTURE_WIDTH, TEXTURE_HEIGHT);      //9
        //static Rectangle DLR = new Rectangle(32, 128, TEXTURE_WIDTH, TEXTURE_HEIGHT);     //10
        //static Rectangle UDLR = new Rectangle(0, 160, TEXTURE_WIDTH, TEXTURE_HEIGHT);     //11

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
            switch (type)
            {
                case 0:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[0], x, y);
                    break;
                case 1:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[1], x, y);
                    break;
                case 2:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[2], x, y);
                    break;
                case 3:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[3], x, y);
                    break;
                case 4:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[4], x, y);
                    break;
                case 5:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[5], x, y);
                    break;
                case 6:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[6], x, y);
                    break;
                case 7:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[7], x, y);
                    break;
                case 8:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[8], x, y);
                    break;
                case 9:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[9], x, y);
                    break;
                case 10:
                    grid.AddSpriteToGrid(sprBat, texture_sheet, textures[10], x, y);
                    break;
            }

            position = new Vector2(x, y);
        }

    }
}
