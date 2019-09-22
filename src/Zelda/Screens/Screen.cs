using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;

namespace Zelda.Screens
{
    public abstract class Screen
    {
        protected Screen(ManagerScreen managerScreen)
        {
            ManagerScreen = managerScreen;
        }

        protected ManagerScreen ManagerScreen { get; }

        public virtual void Initialize()
        {
        }

        public virtual void Uninitialize()
        {
        }

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(double gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
