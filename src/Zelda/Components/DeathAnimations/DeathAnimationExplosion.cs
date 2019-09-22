//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Components.DeathAnimations
{
    class DeathAnimationExplosion : Component
    {
        private enum DeathAnimationState
        {
            Initialize,
            Check
        };

        private DeathAnimationState _currentState; 

        public DeathAnimationExplosion()
        {
            _currentState = DeathAnimationState.Initialize;
        }

        public override void Update(double gameTime)
        {
            var animation = GetComponent<Animation>();
            if (animation == null)
            {
                Done();
                return;
            }

            if (_currentState == DeathAnimationState.Initialize)
            {
                animation.PlayAnimation(State.Walking, Direction.Down);
                _currentState = DeathAnimationState.Check;
            }
            else
            {
                if (animation.CurrentState == State.Standing)
                {
                    Done();
                }
            }
        }

        public void Done()
        {
            KillBaseObject();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
           
        }
    }
}





