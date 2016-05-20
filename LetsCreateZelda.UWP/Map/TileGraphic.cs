//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System.Collections.Generic;
using LetsCreateZelda.UWP.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP.Map
{
    public class TileGraphic : Tile
    {

        public int ZPos { get; set; }

        public List<TileFrame> TileFrames { get; set; }
        public int AnimationSpeed { get; set; }
        private double _counter;
        private int _animationIndex; 

        public string TextureName { get; set; }
        protected Texture2D _texture;



  
        public TileGraphic()
        {    
        }

        public TileGraphic(int xPos, int yPos, int zPos, List<TileFrame> tileFrames, int animationSpeed, string textureName, ManagerCamera managerCamera)
        {
            XPos = xPos;
            YPos = yPos;
            ZPos = zPos;
            TileFrames = tileFrames;
            AnimationSpeed = animationSpeed; 
            TextureName = textureName;
            _animationIndex = 0;
             ManagerCamera = managerCamera; 
        }

        public void LoadContent()
        {
            //_texture = content.Load<Texture2D>(TextureName); 
            _texture = ManagerContent.LoadTexture(TextureName); 
        }

        public virtual void Update(double gameTime)
        {
            if (TileFrames.Count <= 1)
                return;

            _counter += gameTime; 
            if(_counter > AnimationSpeed)
            {
                _counter = 0;
                _animationIndex++;
                if (_animationIndex >= TileFrames.Count)
                    _animationIndex = 0; 
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            var position = ManagerCamera.WorldToScreenPosition(Position);
            if (_texture != null && ManagerCamera.InScreenCheck(Position))
            {
                spriteBatch.Draw(_texture, new Rectangle((int) position.X, (int) position.Y, Width, Height),
                                 new Rectangle(TileFrames[_animationIndex].TextureXPos*(Width + 1) + 1,
                                               TileFrames[_animationIndex].TextureYPos*(Height + 1) + 1,
                                               Width, Height), Color.White);
            }
        }


    }
}
