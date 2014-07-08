using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronPython.Modules;
using LetsCreateZelda.Common;
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
        private Texture2D _playerIconTexture;

        private double _cursorCounter;
        private Vector2 _cursorPosition;
        private OverworldMapObjects _overworldMapObjects; 

        public ScreenOverworldMap(ManagerScreen managerScreen, ManagerPlayer managerPlayer, Vector2 cameraPosition) : base(managerScreen)
        {
            _managerPlayer = managerPlayer;
            _cameraPosition = cameraPosition;
            _cursorPosition = _cameraPosition; 
            _cursorCounter = 0;      
            _overworldMapObjects = new OverworldMapObjects();
        }

        public override void Initialize()
        {
            base.Initialize();
            ManagerInput.ThrottleInput = true; 
            ManagerInput.FireNewInput += ManagerInput_FireNewInput;
        }

        public override void Uninitialize()
        {
            base.Uninitialize();
            ManagerInput.ThrottleInput = false; 
            ManagerInput.FireNewInput -= ManagerInput_FireNewInput;
        }

        void ManagerInput_FireNewInput(object sender, MyEventArgs.NewInputEventArgs e)
        {
            if(e.Input == Input.Select)
                ManagerScreen.GoBackOneScreen();

            switch (e.Input)
            {
                case Input.Left:
                    if (_cursorPosition.X - 1 < 0)
                        return;
                    if (!_managerPlayer.TileExplored((int)_cursorPosition.X - 1, (int)_cursorPosition.Y))
                        return; 
                    _cursorPosition = new Vector2(_cursorPosition.X - 1, _cursorPosition.Y);
                    break;
                case Input.Right:
                    if (_cursorPosition.X + 1 > 15)
                        return;
                    if (!_managerPlayer.TileExplored((int)_cursorPosition.X + 1, (int)_cursorPosition.Y))
                        return; 
                    _cursorPosition = new Vector2(_cursorPosition.X + 1, _cursorPosition.Y);
                    break;
                case Input.Up:
                    if (_cursorPosition.Y - 1 < 0)
                        return;
                    if (!_managerPlayer.TileExplored((int)_cursorPosition.X, (int)_cursorPosition.Y - 1))
                        return; 
                    _cursorPosition = new Vector2(_cursorPosition.X, _cursorPosition.Y - 1);
                    break;
                case Input.Down:
                    if (_cursorPosition.Y + 1 > 15)
                        return;
                    if (!_managerPlayer.TileExplored((int)_cursorPosition.X, (int)_cursorPosition.Y + 1))
                        return; 
                    _cursorPosition = new Vector2(_cursorPosition.X, _cursorPosition.Y + 1);
                    break;
            }
        }

        public override void LoadContent(ContentManager content)
        {
            _mapTexture = content.Load<Texture2D>("overworld_map");
            _firstCursorTexture = content.Load<Texture2D>("map_cursor_1");
            _secondCursorTexture = content.Load<Texture2D>("map_cursor_2");
            _mapBlockTexture = content.Load<Texture2D>("map_block");
            _playerIconTexture = content.Load<Texture2D>("map_player_icon"); 
            _overworldMapObjects.LoadContent(content);

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
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if(_managerPlayer.TileExplored(x,y))
                        continue;

                    spriteBatch.Draw(_mapBlockTexture,new Rectangle(16 + x*8, 8 + y*8,9,9),Color.White);
                }
            }

            spriteBatch.Draw(_cursorCounter > 250 ? _secondCursorTexture : _firstCursorTexture,
                                new Rectangle((int)(3 + _cursorPosition.X * 8), (int)(_cursorPosition.Y * 8 - 5), 36, 36), Color.White);

            spriteBatch.Draw(_playerIconTexture, new Rectangle((int)(18 + _cameraPosition.X * 8), (int)(_cameraPosition.Y * 8 + 10), 6, 6), _cursorCounter > 250 ? Color.White : Color.Red);
            
            _overworldMapObjects.Draw(spriteBatch,_cursorPosition);
        }


    }
}
