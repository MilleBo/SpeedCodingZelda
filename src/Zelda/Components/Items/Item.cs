using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;
using Zelda.Map;

namespace Zelda.Components.Items
{
    public abstract class Item : BaseObject
    {
        public int ItemId { get; set; }

        public bool Active { get; set; }

        public Vector2 MenuPosition { get; set; }

        protected Texture2D GuiTexture { get; set; }

        protected Equipment Owner { get; private set; }

        public abstract void Action();

        public virtual void LoadContent(Equipment owner, ContentManager content, ManagerMap managerMap, ManagerCamera managerCamera, Entities entities)
        {
            Owner = owner;
        }

        public void DrawGui(SpriteBatch spriteBatch, Rectangle rectangle)
        {
            if (GuiTexture != null)
            {
               spriteBatch.Draw(GuiTexture, rectangle, Color.White);
            }
        }

        public void DrawMenu(SpriteBatch spriteBatch)
        {
            if (GuiTexture != null)
            {
                spriteBatch.Draw(GuiTexture, new Rectangle(9 + (32 * (int)MenuPosition.X), 30 + (14 * (int)MenuPosition.Y), 22, 10), Color.White);
            }
        }
    }
}
