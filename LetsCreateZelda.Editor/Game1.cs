#region Using Statements

using System.Threading;
using System.Windows.Forms;
using LetsCreateZelda.Editor.Common;
using LetsCreateZelda.Editor.GUI;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

#endregion

namespace LetsCreateZelda.Editor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private MainForm _mainForm;
        private Common.ManagerMap _map;
        private ManagerCamera _managerCamera;
        private ManagerMouse _mouse;
        private ManagerInput _managerInput; 

        public Game1()
            : base()
        {
            _managerInput = new ManagerInput();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.PreferredBackBufferHeight = 128;
            this.graphics.PreferredBackBufferWidth = 160;

            _managerCamera = new ManagerCamera();

            _mainForm = new MainForm(_managerCamera);
            var thread = new Thread(new ThreadStart(new ThreadStart(RunGUI))); 
            thread.Start();

            
            
        }

        private void RunGUI()
        {
           Application.Run(_mainForm);
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
            ManagerContent.Initialize(Content);
            _mouse = new ManagerMouse(_managerCamera,_mainForm);
            _map = new Common.ManagerMap(_managerCamera,_mouse, _mainForm); 

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

            // TODO: Add your update logic here
            _mouse.Update(gameTime.ElapsedGameTime.Milliseconds);
            _map.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerInput.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerCamera.Update(gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(196, 207, 161));
            spriteBatch.Begin();
            _map.Draw(spriteBatch);
            _mouse.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}


//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
//------------------------------------------------------


