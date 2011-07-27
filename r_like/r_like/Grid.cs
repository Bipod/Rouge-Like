using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace r_like
{
    class Grid
    {

        //public void Draw(SpriteBatch sprBat, Creature creature)
        //{
        //    sprBat.Draw(creature.texture, creature.position, Color.White);
        //}

        public void Move(SpriteBatch sprBat, Texture2D texture, Vector2 direction, Creature creature)
        {
            sprBat.Draw(texture, new Rectangle((int)(direction.X) +texture.Width, (int)(direction.Y) + texture.Height,
               texture.Width, texture.Height), Color.White);
        }

        public void Draw(SpriteBatch sprBat, Texture2D texture, Vector2 position, Color color)
        {
            sprBat.Draw(texture, position, color);
        }

    }
}
