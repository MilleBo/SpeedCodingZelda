using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Zelda.Editor.GUI;
using Zelda.Manager;

namespace LetsCreateZelda.Editor.Common
{
    class ManagerMouse
    {
        private Texture2D _texture;
        private MouseState _mouseState;
        public int XTile { get; private set; }
        public int YTile { get; private set; }

        private ManagerCamera _managerCamera;
        public Vector2 Position { get; private set; }

        private MainForm _mainForm; 

        public ManagerMouse(ManagerCamera managerCamera, MainForm mainForm)
        {
            _texture = ManagerContent.LoadTexture("mouse");
            _managerCamera = managerCamera;
            _mainForm = mainForm;
        }

        public void Update(double gameTime)
        {
            _mouseState = Mouse.GetState();

            XTile = (int) ((_mouseState.X + _managerCamera.Position.X)/16);
            YTile = (int) ((_mouseState.Y + _managerCamera.Position.Y)/16);
            Position = new Vector2(XTile*16,YTile*16);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_texture, new Rectangle((int) _managerCamera.WorldToScreenPosition(Position).X,(int) _managerCamera.WorldToScreenPosition(Position).Y,
            //    16,16),Color.White);

            foreach (var tilePoint in _mainForm.TilePoints)
            {
                var realX = XTile + (_mainForm.TilePoints[0].X - tilePoint.X) * -1;
                var realY = YTile + (_mainForm.TilePoints[0].Y - tilePoint.Y) * -1;
                var position = new Vector2(realX*16, realY*16);
                spriteBatch.Draw(_texture, new Rectangle((int)_managerCamera.WorldToScreenPosition(position).X, (int)_managerCamera.WorldToScreenPosition(position).Y,
                    16, 16), Color.White);
            }

        }



    }
}


//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
//------------------------------------------------------


