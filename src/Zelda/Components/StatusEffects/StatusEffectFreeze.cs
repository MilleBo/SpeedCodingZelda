using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Components.StatusEffects
{
    class StatusEffectFreeze : StatusEffectBase
    {
        private enum States { Start, Wait, End};

        private States _currentState;

        private double _count;

        private float _oldSpeed;
        private Color _oldColor; 

        public StatusEffectFreeze(BaseObject baseObject) : base(baseObject)
        {
            _currentState = States.Start;
        }

        public override void Update(double gameTime)
        {
            var stats = BaseObject.GetComponent<Stats>();
            var sprite = BaseObject.GetComponent<Sprite>();
            switch (_currentState)
            {
                case States.Start:
                    
                    if (stats != null)
                    {
                        _oldSpeed = stats.Speed; 
                        stats.Speed = 0; 
                    }
                    if (sprite != null)
                    {
                        _oldColor = sprite.Color; 
                        sprite.Color = Color.Blue;
                    }
                    _currentState = States.Wait;
                    break;
                case States.Wait:
                    _count += gameTime;
                    if (_count > 1000)
                    {
                        _currentState = States.End;
                    }
                    break;
                case States.End:
                    if (stats != null)
                    {
                        stats.Speed = _oldSpeed;
                    }            
                    if (sprite != null)
                    {
                        sprite.Color = _oldColor; 
                    }
                    Done = true; 
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public override void Stacking()
        {
            _count = 0; 
        }
    }
}
