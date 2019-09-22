using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Common.Requests;
using Zelda.Factories;
using Zelda.Manager;
using Zelda.Screens;

namespace Zelda
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ZeldaGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private readonly ManagerInput _managerInput;
        private RenderTarget2D backBuffer;
        private SpriteBatch spriteBatch;
        private ManagerScreen _managerScreen;
        private ManagerWindow _managerWindow;
        private ManagerLists _managerLists;

        public ZeldaGame()
            : base()
        {
            Window.AllowUserResizing = true;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 144;
            graphics.PreferredBackBufferWidth = 160;
            _managerInput = new ManagerInput();
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

            var connection = new HubConnection("http://localhost:8080");
            var characterMoveHub = connection.CreateHubProxy("gameHub");
            characterMoveHub.On("hello", () =>
            {
                var i = 0;
                i++;
            });

            connection.Start();

            Thread.Sleep(2000);

            characterMoveHub.Invoke("Login", new LoginRequest { Name = "bugu" });
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            backBuffer = new RenderTarget2D(GraphicsDevice, 160, 144);
            ManagerContent.Initialize(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _managerScreen = new ManagerScreen(Content);
            _managerWindow = new ManagerWindow();
            _managerLists = new ManagerLists();
            _managerLists.Initialize();
            _managerScreen.LoadNewScreen(new ScreenStart(_managerScreen), false);
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
            _managerInput.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerWindow.Update(gameTime.ElapsedGameTime.Milliseconds);
            _managerScreen.Update(gameTime.ElapsedGameTime.Milliseconds);

            base.Update(gameTime);
        }

        protected override bool BeginDraw()
        {
            GraphicsDevice.SetRenderTarget(backBuffer);
            GraphicsDevice.Clear(new Color(196, 207, 161));
            spriteBatch.Begin();
            _managerScreen.Draw(spriteBatch);
            _managerWindow.Draw(spriteBatch);
            spriteBatch.End();
            return base.BeginDraw();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(new Color(196, 207, 161));
            spriteBatch.Begin();
            spriteBatch.Draw(backBuffer, new Rectangle(0, 0, GraphicsDevice.Viewport.Bounds.Width, GraphicsDevice.Viewport.Bounds.Height), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
