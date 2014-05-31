using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Components;
using LetsCreateZelda.Gui;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OpenTK.Graphics.OpenGL;
using Tao.Sdl;

namespace LetsCreateZelda.Screens
{
    class ScreenMainMenu : Screen
    {
        private Texture2D _tempTexture;
        private Texture2D _rupeeTexture;
        private Texture2D _heartTexture;
        private Texture2D _containerTexture;
        private Texture2D _backgroundTexture;
        private Texture2D _barHor;
        private Texture2D _barVert;
        private SpriteFont _font;
        private Stats _stats;
        private PlayerStatsGui _playerStatsGui;
        private Vector2 _cursorPosition;
        private double _cursorBlinkCounter; 
        

        public ScreenMainMenu(ManagerScreen managerScreen, Stats stats) : base(managerScreen)
        {
            _stats = stats; 
            if(stats == null)
                managerScreen.GoBackOneScreen();
            _playerStatsGui = new PlayerStatsGui(_stats,WindowPosition.Up);
            ManagerInput.FireNewInput += ManagerInput_FireNewInput;
            ManagerInput.ThrottleInput = true; 
            _cursorPosition = new Vector2(0,0);
        }

        void ManagerInput_FireNewInput(object sender, MyEventArgs.NewInputEventArgs e)
        {
            switch (e.Input)
            {
                case Input.Left:
                    _cursorPosition.X--;
                    if (_cursorPosition.X < 0)
                    {
                        _cursorPosition.X = 1;
                        _cursorPosition.Y--;
                        if (_cursorPosition.Y < 0)
                        {
                            _cursorPosition.Y = 7;
                        }
                    }
                    break;

                case Input.Right:
                    _cursorPosition.X++;
                    if (_cursorPosition.X > 1)
                    {
                        _cursorPosition.X = 0;
                        _cursorPosition.Y++;
                        if (_cursorPosition.Y > 7)
                            _cursorPosition.Y = 0;
                    }
                    break;

                case Input.Down:
                    _cursorPosition.Y++;
                    if (_cursorPosition.Y > 7)
                    {
                        _cursorPosition.X = 0;
                        _cursorPosition.Y = 0;
                    }
                    break;

                case Input.Up:
                    _cursorPosition.Y--;
                    if (_cursorPosition.Y < 0)
                    {
                        _cursorPosition.X = 1;
                        _cursorPosition.Y = 7;
                    }
                    break;
                case Input.Select:
                    ManagerScreen.GoBackOneScreen();
                    break; 
            }

        }

        public override void LoadContent(ContentManager content)
        {
            _rupeeTexture = content.Load<Texture2D>("rupee_gui");
            _heartTexture = content.Load<Texture2D>("heart_gui");
            _containerTexture = content.Load<Texture2D>("container_gui");
            _font = content.Load<SpriteFont>("Font_GUI");
            _tempTexture = content.Load<Texture2D>("boomerang_gui");
            _backgroundTexture = content.Load<Texture2D>("white_background");
            _barHor = content.Load<Texture2D>("menu_block_hor");
            _barVert = content.Load<Texture2D>("menu_block_vert");
            _playerStatsGui.LoadContent(content);
        }

        public override void Update(double gameTime)
        {
            _cursorBlinkCounter += gameTime;
            if (_cursorBlinkCounter > 600)
                _cursorBlinkCounter = 0; 
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, 160, 144), new Color(245, 245, 135));

            for (int n = 0; n < 10; n++)
            {
                spriteBatch.Draw(_barHor,new Rectangle(n*20,18,17,4),Color.White);
                spriteBatch.Draw(_barVert, new Rectangle(75, 25 + n*20, 4, 17), Color.White);
            }

            spriteBatch.Draw(_containerTexture, new Rectangle((int) (9 + 32*_cursorPosition.X),(int) (30 + 14*_cursorPosition.Y), 30, 12), _cursorBlinkCounter < 300 ? Color.White : Color.Transparent);
            _playerStatsGui.Draw(spriteBatch);
            spriteBatch.DrawString(_font,"PUSH SELECT",new Vector2(90,130),Color.Black);
        }
    }
}
