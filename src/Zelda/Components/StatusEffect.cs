using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Components.StatusEffects;

namespace Zelda.Components
{
    public class StatusEffect : Component
    {
        public StatusEffect()
        {
            StatusEffects = new List<StatusEffectBase>();
        }

        private List<StatusEffectBase> StatusEffects { get; }

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
            {
                return;
            }

            int i = 0;
            while (i < StatusEffects.Count)
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
