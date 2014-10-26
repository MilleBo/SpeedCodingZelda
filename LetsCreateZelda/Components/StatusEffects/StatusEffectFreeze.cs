using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components.StatusEffects
{
    class StatusEffectFreeze : IStatusEffect
    {
        private readonly BaseObject _baseObject;
        private enum States { Start, Wait, End};

        private States _currentState;

        private double _count;

        private float _oldSpeed;
        private Color _oldColor; 

        public StatusEffectFreeze(BaseObject baseObject)
        {
            _baseObject = baseObject;
            _currentState = States.Start;
        }

        public bool Done { get; set; }
        public void Update(double gameTime)
        {
            var stats = _baseObject.GetComponent<Stats>(ComponentType.Stats);
            var sprite = _baseObject.GetComponent<Sprite>(ComponentType.Sprite);
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

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
