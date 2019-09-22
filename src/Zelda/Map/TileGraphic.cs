using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;

namespace Zelda.Map
{
    public class TileGraphic : Tile
    {
        private double _counter;
        private int _animationIndex;

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

        public int ZPos { get; set; }

        public List<TileFrame> TileFrames { get; set; }

        public int AnimationSpeed { get; set; }

        public string TextureName { get; set; }

        protected Texture2D Texture { get; private set; }

        public void LoadContent()
        {
            Texture = ManagerContent.LoadTexture(TextureName);
        }

        public virtual void Update(double gameTime)
        {
            if (TileFrames.Count <= 1)
            {
                return;
            }

            _counter += gameTime;
            if (_counter > AnimationSpeed)
            {
                _counter = 0;
                _animationIndex++;
                if (_animationIndex >= TileFrames.Count)
                {
                    _animationIndex = 0;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            var position = ManagerCamera.WorldToScreenPosition(Position);
            if (Texture != null && ManagerCamera.InScreenCheck(Position))
            {
                spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, Width, Height), new Rectangle((TileFrames[_animationIndex].TextureXPos * (Width + 1)) + 1,  (TileFrames[_animationIndex].TextureYPos * (Height + 1)) + 1,  Width, Height), Color.White);
            }
        }
    }
}
