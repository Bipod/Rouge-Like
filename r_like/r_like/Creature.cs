using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace r_like
{
    class Creature : Grid
    {
        public Vector2 position;
        private Texture2D texture;

        public void LoadContent(ContentManager conMan, string name)
        {
            texture = conMan.Load<Texture2D>(name);
        }

        public void Draw(SpriteBatch sprBat)
        {
            base.Draw(sprBat, texture, position, Color.White);
        }

    }
}
