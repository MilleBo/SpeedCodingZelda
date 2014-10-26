using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using LetsCreateZelda.Components.StatusEffects;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components
{
    class StatusEffect : Component
    {
        public override ComponentType ComponentType
        {
            get { return ComponentType.StatusEffects; }
        }

        public List<IStatusEffect> StatusEffects { get; set; }  

        public StatusEffect()
        {
            StatusEffects = new List<IStatusEffect>();
        }

        public override void Update(double gameTime)
        {
            if (StatusEffects.Count == 0)
                return;
            int i = 0;
            while(i < StatusEffects.Count)
            {
                StatusEffects[i].Update(gameTime);
                if (StatusEffects[i].Done)
                {
                    StatusEffects.RemoveAt(i);
                }
                else
                {
                    i++; 
                }
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            
        }
    }
}
