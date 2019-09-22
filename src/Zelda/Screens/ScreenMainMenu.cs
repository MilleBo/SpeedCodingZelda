using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Components;
using Zelda.Gui;
using Zelda.Manager;

namespace Zelda.Screens
{
    public class ScreenMainMenu : Screen
    {
        private readonly Equipment _equipment;
        private readonly Stats _stats;
        private readonly PlayerStatsGui _playerStatsGui;
        private Texture2D _tempTexture;
        private Texture2D _rupeeTexture;
        private Texture2D _heartTexture;
        private Texture2D _containerTexture;
        private Texture2D _backgroundTexture;
        private Texture2D _barHor;
        private Texture2D _barVert;
        private SpriteFont _font;

        private Vector2 _cursorPosition;
        private double _cursorBlinkCounter;
        private byte _selectAlpha;
        private byte _instrumentColor;

        public ScreenMainMenu(ManagerScreen managerScreen, Stats stats, Equipment equipment)
            : base(managerScreen)
        {
            _stats = stats;
            _equipment = equipment;
            if (stats == null)
            {
                managerScreen.GoBackOneScreen();
            }

            _playerStatsGui = new PlayerStatsGui(WindowPosition.Up);
            _cursorPosition = new Vector2(0, 0);
            _selectAlpha = 255;
            _instrumentColor = 255;
        }

        public override void Initialize()
        {
            ManagerInput.FireNewInput -= ManagerInput_FireNewInput;
            ManagerInput.FireNewInput += ManagerInput_FireNewInput;
            ManagerInput.ThrottleInput = true;
        }

        public override void Uninitialize()
        {
            ManagerInput.FireNewInput -= ManagerInput_FireNewInput;
        }

        public override void LoadContent(ContentManager content)
        {
            _rupeeTexture = ManagerContent.LoadTexture("rupee_gui");
            _heartTexture = ManagerContent.LoadTexture("heart_gui");
            _containerTexture = ManagerContent.LoadTexture("container_gui");
            _font = ManagerContent.LoadFont("Font_GUI");
            _tempTexture = ManagerContent.LoadTexture("boomerang_gui");
            _backgroundTexture = ManagerContent.LoadTexture("white_background");
            _barHor = ManagerContent.LoadTexture("menu_block_hor");
            _barVert = ManagerContent.LoadTexture("menu_block_vert");
            _playerStatsGui.LoadContent(content);
        }

        public override void Update(double gameTime)
        {
            _cursorBlinkCounter += gameTime;
            if (_cursorBlinkCounter > 600)
            {
                _cursorBlinkCounter = 0;
                if (_selectAlpha == 255)
                {
                    _selectAlpha = 0;
                }
                else
                {
                    _selectAlpha = 255;
                }
            }

            _playerStatsGui.Update(_stats, _equipment);

            _instrumentColor += 1;
            if (_instrumentColor > 255)
            {
                _instrumentColor = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, 160, 144), new Color(245, 245, 135));

            for (int n = 0; n < 10; n++)
            {
                spriteBatch.Draw(_barHor, new Rectangle(n * 20, 18, 17, 4), Color.White);
                spriteBatch.Draw(_barVert, new Rectangle(75, 25 + (n * 20), 4, 17), Color.White);
            }

            _equipment.DrawMenuGui(spriteBatch);
            spriteBatch.Draw(_containerTexture, new Rectangle((int)(9 + (32 * _cursorPosition.X)), (int)(30 + (14 * _cursorPosition.Y)), 30, 12), _cursorBlinkCounter < 300 ? Color.White : Color.Transparent);
            _playerStatsGui.Draw(spriteBatch);
            spriteBatch.DrawString(_font, "PUSH SELECT", new Vector2(90, 130), new Color((byte)0, (byte)0, (byte)0, _selectAlpha));
            DrawInstrument(spriteBatch);
        }

        private void DrawInstrument(SpriteBatch spriteBatch)
        {
            double x;
            double y;
            var length = 30;
            var angle = 0.0;
            int i = 0;
            while (angle < 2 * Math.PI)
            {
                x = length * Math.Cos(angle);
                y = length * Math.Sin(angle);

                spriteBatch.Draw(_backgroundTexture, new Rectangle(120 + (int)x, 85 + (int)y, 5, 5), new Color(_instrumentColor, 255, 255));
                spriteBatch.Draw(_backgroundTexture, new Rectangle(115 + (int)x, 85 + (int)y, 5, 5), new Color(_instrumentColor, 255, 255));
                spriteBatch.Draw(_backgroundTexture, new Rectangle(115 + (int)x, 90 + (int)y, 5, 5), new Color(_instrumentColor, 255, 255));
                spriteBatch.DrawString(_font, i.ToString(), new Vector2(120 + (int)x, 85 + (int)y), Color.Black);
                angle += 0.8;
                i++;
            }
        }

        private void ManagerInput_FireNewInput(object sender, MyEventArgs.NewInputEventArgs e)
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
                        {
                            _cursorPosition.Y = 0;
                        }
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
                case Input.A:
                    _equipment.SwitchEquipment(ItemSlot.A, _cursorPosition);
                    break;
                case Input.S:
                    _equipment.SwitchEquipment(ItemSlot.B, _cursorPosition);
                    break;
            }
        }
    }
}