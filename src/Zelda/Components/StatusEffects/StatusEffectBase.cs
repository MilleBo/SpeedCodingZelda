using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Components.StatusEffects
{
    public abstract class StatusEffectBase
    {
        protected StatusEffectBase(BaseObject baseObject)
        {
            BaseObject = baseObject;
        }

        public BaseObject BaseObject { get; }

        public bool Done { get; set; }

        public abstract void Update(double gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Stacking();
    }
}
