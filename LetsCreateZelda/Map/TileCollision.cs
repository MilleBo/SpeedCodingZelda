using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Map
{
    public class TileCollision : Tile
    {

        private Texture2D _texture;

        public TileCollision() { }

        public TileCollision(bool mapEditor)
        {
            if (mapEditor)
               LoadContent();
        }

        public void LoadContent()
        {
            _texture = ManagerContent.LoadTexture("cross"); 
        }

        public bool Intersect(Rectangle rectangle)
        {
            var position = new Vector2(Rectangle.X, Rectangle.Y);
            return ManagerCamera.InScreenCheck(position) && rectangle.Intersects(new Rectangle((int) position.X,(int) position.Y,16,16)); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_texture == null)
                return; 

            var position = ManagerCamera.WorldToScreenPosition(Position);
            if (ManagerCamera.InScreenCheck(Position))
            {
                spriteBatch.Draw(_texture, new Rectangle((int)position.X, (int)position.Y, Width, Height),
                                 new Rectangle(0,0,Width, Height), Color.White);
            }
        }


    }
}
