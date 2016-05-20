using System.Collections.Generic;
using System.Linq;
using LetsCreateZelda.UWP.Components.StatusEffects;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP.Components
{
    class StatusEffect : Component
    {
        private List<StatusEffectBase> StatusEffects { get; }  

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
