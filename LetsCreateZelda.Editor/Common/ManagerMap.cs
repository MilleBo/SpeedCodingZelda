using System;
using System.Collections.Generic;
using System.IO;
using LetsCreateZelda.Editor.GUI;
using LetsCreateZelda.Manager;
using LetsCreateZelda.Map;
using LetsCreateZelda.MyEventArgs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LetsCreateZelda.Editor.Common
{
    class ManagerMap
    {
        private LetsCreateZelda.Manager.ManagerMap _tiles; 
        private ManagerMouse _managerMouse; 
        private ManagerCamera _managerCamera;
        private Texture2D _tileGridTexture;
        private SpriteFont _font;
        private MouseState _mouseState;
        private MainForm _mainForm;

        public ManagerMap(ManagerCamera camera, ManagerMouse managerMouse, MainForm mainForm)
        {
            _managerCamera = camera;
            _managerMouse = managerMouse;
            _tiles = new Manager.ManagerMap("..", camera);
            _tileGridTexture = ManagerContent.LoadTexture("tile_mapeditor");
            _font = ManagerContent.LoadFont("Font_GUI");
            _mainForm = mainForm;
            _mainForm.btnSave.Click += Save;
            _mainForm.LoadMap += LoadMap;
            ManagerInput.FireNewInput += ManagerInputOnFireNewInput;
            ManagerInput.ThrottleInput = true;            
        }

        void LoadMap(object sender, MyEventArgs.MapNameEventArgs e)
        {
            _tiles = new Manager.ManagerMap(e.MapName, _managerCamera);
            _tiles.LoadContent();
            _tiles.LoadCollisionTexture();
        }

        void Save(object sender, EventArgs e)
        {
            DirectoryUtility.EnsureDirectory(_mainForm.FileName);
            _tiles.Save(_mainForm.FileName); 
        }

        private void ManagerInputOnFireNewInput(object sender, NewInputEventArgs e)
        {
            switch (e.Input)
            {
                 case Input.Left:
                _managerCamera.Move(Direction.Left);
                    break; 
                case Input.Right:
                    _managerCamera.Move(Direction.Right);
                    break; 
                case Input.Up:
                    _managerCamera.Move(Direction.Up);
                    break; 

                case Input.Down:
                    _managerCamera.Move(Direction.Down);
                    break; 
            }

            _mainForm.UpdateCameraPositionText();
        }

        public void Update(double gameTime)
        {
            _mouseState = Mouse.GetState();

            if (_mouseState.LeftButton == ButtonState.Pressed && _managerCamera.MouseInsideWindow())
            {
                var x = (int)(_managerCamera.Position.X + _mouseState.X)/16;
                var y = (int)(_managerCamera.Position.Y + _mouseState.Y)/16;

                //Just for test

                if (_mainForm.CurrentLayer == CurrentLayer.LayerOne)
                {
                    foreach (var tilePoint in _mainForm.TilePoints)
                    {
                        var realX = x + (_mainForm.TilePoints[0].X - tilePoint.X)*-1;
                        var realY = y + (_mainForm.TilePoints[0].Y - tilePoint.Y)*-1; 

                        var tile = new TileGraphic
                                   {
                                       ManagerCamera = _managerCamera,
                                       XPos = (int)realX,
                                       YPos = (int)realY,
                                       AnimationSpeed = 0,
                                       TextureName = "overworld_tiles",
                                       TileFrames =
                                           new List<TileFrame>
                                           {
                                               new TileFrame
                                               {
                                                   TextureXPos = (int)tilePoint.X,
                                                   TextureYPos = (int)tilePoint.Y
                                               }
                                           },
                                       ZPos = 0
                                   };
                        tile.LoadContent();
                        _tiles.AddTile(tile);
                    }
                }
                else
                {
                    var tileCollision = new TileCollision(true)
                                        {
                                            ManagerCamera = _managerCamera,
                                            XPos = x,
                                            YPos = y
                                        };
                    _tiles.AddCollisionTile(tileCollision); 
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            _tiles.Draw(spriteBatch);
            _tiles.DrawCollision(spriteBatch);

            for (int n = 0; n < 10; n++)
            {
                for (int i = 0; i < 8; i++)
                {
                    spriteBatch.Draw(_tileGridTexture, new Rectangle(n * 16, i * 16, 16, 16), Color.White);
                }
            }
            
           //spriteBatch.DrawString(_font, string.Format("({0}.{1}",_managerCamera.Position.X,_managerCamera.Position.Y), new Vector2(5,5),Color.Green);
        }



    }

 }


//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
//------------------------------------------------------


