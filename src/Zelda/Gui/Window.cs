using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;

namespace Zelda.Gui
{
    public abstract class Window
    {
        protected Window()
        {
            FontColor = Color.White;
            AMenu = false;
            Opacity = 255;
            Color = Color.Black;
            Font = ManagerContent.LoadFont("Font_GUI");
            Texture = ManagerContent.LoadTexture("white_background");
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public Color Color { get; set; }

        public bool Done { get; set; }

        public bool Active { get; set; }

        public bool AMenu { get; set; }

        public byte Opacity { get; set; }

        public Vector2 Position { get; set; }

        protected SpriteFont Font { get; private set; }

        protected Texture2D Texture { get; private set; }

        protected Color FontColor { get; private set; }

        public virtual void LoadContent(ContentManager content)
        {
        }

        public abstract void Update(double gameTime);

        public abstract void Reset();

        public virtual void DeInitialize()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), Color);
        }
    }
}
