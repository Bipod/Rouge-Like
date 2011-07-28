using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace r_like
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class r_like : Microsoft.Xna.Framework.Game
    {
        // Static variables or whatever they're called.
        const int SCREEN_WIDTH = 800;
        const int SCREEN_HEIGHT = 800;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Grid grid;
        Player player;
        Creature creature;
        Wall wall;
        RoomGen room_gen;
        List<RoomGen.wall_positions> walls = new List<RoomGen.wall_positions>();

        public r_like()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            grid = new Grid();

            player = new Player(grid);
            creature = new Creature(grid);
            wall = new Wall(grid);
            room_gen = new RoomGen();
            room_gen.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadTexture(this.Content, "player");
            creature.LoadTexture(this.Content, "ghost");
            grid.LoadTexture(this.Content, "grid_square");
            wall.LoadTexture(this.Content, "wall");

            for (int i = 0; i < room_gen.GetRoomTypesSize(); i++)
            {
                walls.Add(room_gen.GetWallPositions(i));
                Console.WriteLine(walls[i].TYPE);
            }

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (player.Update())
                creature.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            grid.DrawGrid(spriteBatch);
            player.Draw(spriteBatch);
            creature.Draw(spriteBatch);

            for (int i = 0; i < walls.Count; i++)
            {
                wall.Draw(spriteBatch, walls[i].X, walls[i].Y, walls[i].TYPE);
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
