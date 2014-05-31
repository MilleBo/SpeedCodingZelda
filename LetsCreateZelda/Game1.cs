#region Using Statements
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using LetsCreateZelda.Components;
using LetsCreateZelda.Components.Enemies;
using LetsCreateZelda.Components.Movement;
using LetsCreateZelda.Factories;
using LetsCreateZelda.Manager;
using LetsCreateZelda.Map;
using LetsCreateZelda.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace LetsCreateZelda
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private ManagerInput _managerInput;
        private ManagerScreen _managerScreen;
        private ManagerWindow _managerWindow;
        private ManagerLists _managerLists; 


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.PreferredBackBufferHeight = 144;
            this.graphics.PreferredBackBufferWidth = 160; 
            _managerInput = new ManagerInput();
            Console.WriteLine("hej hej");
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            FactoryStats.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            ManagerContent.Initialize(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _managerScreen = new ManagerScreen(Content);
            _managerWindow = new ManagerWindow();
            _managerLists = new ManagerLists();
            _managerLists.Initialize();
            //_managerScreen.LoadNewScreen(new ScreenWorld(_managerScreen));
            _managerScreen.LoadNewScreen(new ScreenStart(_managerScreen));
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _managerInput.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerWindow.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerScreen.Update(gameTime.ElapsedGameTime.Milliseconds);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(196,207,161));

            spriteBatch.Begin();
            _managerScreen.Draw(spriteBatch);
            _managerWindow.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
