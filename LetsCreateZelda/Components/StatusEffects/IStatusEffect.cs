using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components.StatusEffects
{
    interface IStatusEffect
    {
        bool Done { get; set; }
        void Update(double gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
