using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using LetsCreateZelda.Factories;
using LetsCreateZelda.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components
{
    class Damage : Component
    {
        private bool _takingDamage;
        private Direction _direction;
        private Entities _entities;
        private double _counter;
        private double _blinkCounter; 
        private int _speed;
        private bool _hitDamage; 

        public Damage(Entities entities, bool hitDamage = false)
        {
            _takingDamage = false;
            _entities = entities;
            _speed = 1;
            _hitDamage = hitDamage; 
        }

        public override ComponentType ComponentType
        {
            get { return ComponentType.Damage; }
        }

        public void TakingDamage(Direction direction, int damage)
        {
            if(!_takingDamage)
                ReduceHealth(damage);
            _takingDamage = true;
            _direction = direction;
            _counter = 0;
            _blinkCounter = 0;       
        }

        protected virtual void ReduceHealth(int damage)
        {
            var stats = GetComponent<Stats>(ComponentType.Stats);
            if (stats == null)
                return; 
            stats.ReduceHealth(damage);
            if (stats.CurrentHealth <= 0)
            {
                var sprite = GetComponent<Sprite>(ComponentType.Sprite);
                if (sprite == null)
                    return;
                _entities.AddEntity(FactoryDeathAnimation.GetDeathAnimationObject(DeathAnimation.Explosion,
                    sprite.Position));
            }
        }

        public override void Update(double gameTime)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            if (sprite == null)
                return;
            Animation outAnimation;
            BaseObject outBaseObject; 
            if (_hitDamage && _takingDamage == false && _entities.CheckCollision(sprite.Rectangle,out outAnimation, out outBaseObject, GetOwnerId()))
            {                
                //TakingDamage(outAnimation != null ? outAnimation.CurrentDirection : Direction.Up);
                var animation = GetComponent<Animation>(ComponentType.Animation);
                var direction = Direction.Up; 
                if (animation != null)
                {
                    switch (animation.CurrentDirection)
                    {
                        case Direction.Down:
                            direction = Direction.Up;
                            break; 

                        case Direction.Left:
                            direction = Direction.Right; 
                            break; 

                        case Direction.Right:
                            direction = Direction.Left; 
                            break; 

                        case Direction.Up:
                            direction = Direction.Down; 
                            break; 

                    }
                }
                TakingDamage(direction,1);
            }


            if (_takingDamage)
            {
                _counter += gameTime;
                _blinkCounter += gameTime; 
                var animation = GetComponent<Animation>(ComponentType.Animation); 
                if(animation != null)
                    animation.LockAnimation = true;
                var collision = GetComponent<Collision>(ComponentType.Collision);

                var x = _direction == Direction.Left ? -1*_speed : _direction == Direction.Right ? 1*_speed : 0;
                var y = _direction == Direction.Up ? -1*_speed : _direction == Direction.Down ? 1*_speed : 0; 

                if(collision != null && !collision.CheckCollision(new Rectangle((int) (sprite.Position.X + x) ,(int) (sprite.Position.Y + y),sprite.Width,sprite.Height)))
                    sprite.Move(_direction, _speed);

                if (_blinkCounter > 30)
                {
                    _blinkCounter = 0;
                    sprite.Color = sprite.Color == Color.White ? Color.Red : Color.White; 
                }

                if (_counter > 500)
                {
                    _takingDamage = false;
                    sprite.Color = Color.White; 
                    if (animation != null)
                        animation.LockAnimation = false;
                }
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            
        }
    }
}
