using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Gui
{
    abstract class Window
    {
        public Vector2 Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        protected SpriteFont Font;
        protected Texture2D Texture;
        protected Color FontColor;
        public Color Color { get; set; }
        public bool Done { get; set; }
        public bool Active { get; set; }
        public bool AMenu { get; set; }
        public byte Opacity { get; set; }
        
        protected Window()
        {
            FontColor = Color.White;
            AMenu = false;
            Opacity = 255;
            Color = Color.Black;
            Font = ManagerContent.LoadFont("Font_GUI"); 
            Texture = ManagerContent.LoadTexture("white_background");
        }

        public virtual void LoadContent(ContentManager content)
        {
            
        }

        public abstract void Update(double gameTime);
        public abstract void Reset();
        public virtual void DeInitialize() {}

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture,new Rectangle((int) Position.X,(int) Position.Y,Width,Height),Color);
        }
    }
}
