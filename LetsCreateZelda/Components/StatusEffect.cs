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

        private List<StatusEffectBase> StatusEffects { get; set; }  

        public StatusEffect()
        {
            StatusEffects = new List<StatusEffectBase>();
        }

        public void AddStatusEffect(StatusEffectBase statusEffect)
        {
            var oldStatusEffect = StatusEffects.FirstOrDefault(s => statusEffect.GetType() == s.GetType()
                                                                    && s.BaseObject.Id == statusEffect.BaseObject.Id
                                                                    && s.Done == false);
            if (oldStatusEffect != null)
            {
                oldStatusEffect.Stacking();
            }
            else
            {
                StatusEffects.Add(statusEffect);
            }
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
