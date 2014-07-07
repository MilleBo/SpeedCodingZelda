using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronPython.Modules;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Screens
{
    class ScreenOverworldMap : Screen
    {
        private readonly ManagerPlayer _managerPlayer;
        private readonly Vector2 _cameraPosition;
        private Texture2D _mapTexture;
        private Texture2D _firstCursorTexture;
        private Texture2D _secondCursorTexture;
        private Texture2D _mapBlockTexture;
        private double _cursorCounter; 

        public ScreenOverworldMap(ManagerScreen managerScreen, ManagerPlayer managerPlayer, Vector2 cameraPosition) : base(managerScreen)
        {
            _managerPlayer = managerPlayer;
            _cameraPosition = cameraPosition;
            _cursorCounter = 0;
           
        }

        public override void Initialize()
        {
            base.Initialize();
            ManagerInput.FireNewInput += ManagerInput_FireNewInput;
        }

        public override void Uninitialize()
        {
            base.Uninitialize();
            ManagerInput.FireNewInput -= ManagerInput_FireNewInput;
        }

        void ManagerInput_FireNewInput(object sender, MyEventArgs.NewInputEventArgs e)
        {
            if(e.Input == Input.Select)
                ManagerScreen.GoBackOneScreen();
        }

        public override void LoadContent(ContentManager content)
        {
            _mapTexture = content.Load<Texture2D>("overworld_map");
            _firstCursorTexture = content.Load<Texture2D>("map_cursor_1");
            _secondCursorTexture = content.Load<Texture2D>("map_cursor_2");
            _mapBlockTexture = content.Load<Texture2D>("map_block");
        }

        public override void Update(double gameTime)
        {
            _cursorCounter += gameTime;
            if (_cursorCounter > 500)
                _cursorCounter = 0; 
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_mapTexture,new Vector2(0,0),Color.White);
            for (int n = 0; n < 16; n++)
            {
                for (int i = 0; i < 16; i++)
                {
                    if(_managerPlayer.ExploredMapTiles.Any(p => p.X == n && p.Y == i))
                        continue;

                    spriteBatch.Draw(_mapBlockTexture,new Rectangle(16 + n*7 + n, 8 + i*7 + i,9,9),Color.White);
                }
            }
            spriteBatch.Draw(_cursorCounter > 250 ? _secondCursorTexture : _firstCursorTexture,
    new Rectangle((int)(3 + _cameraPosition.X * 7 + _cameraPosition.X), (int)(_cameraPosition.Y * 7 - 5 + _cameraPosition.Y), 36, 36), Color.White);

        }
    }
}
