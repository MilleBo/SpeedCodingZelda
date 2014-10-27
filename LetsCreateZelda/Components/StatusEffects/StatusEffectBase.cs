using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components.StatusEffects
{
    abstract class StatusEffectBase
    {
        public BaseObject BaseObject { get; private set; }

        protected StatusEffectBase(BaseObject baseObject)
        {
            BaseObject = baseObject;
        }

        public bool Done { get; set; }
        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Stacking(); 

    }
}
