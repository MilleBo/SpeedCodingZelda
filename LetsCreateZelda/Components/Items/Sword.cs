using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using LetsCreateZelda.Manager;
using LetsCreateZelda.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components.Items
{
    class Sword : Item
    {
        private double _counter;
        private Entities _entities;

        public Sword(Entities entities)
        {
            ItemId = 2;
            _entities = entities; 
        }

        public override void Action()
        {
            var ownerAnimation = Owner.GetComponent<Animation>(ComponentType.Animation);
            var ownerSprite = Owner.GetComponent<Sprite>(ComponentType.Sprite);
            if (ownerAnimation == null || ownerSprite == null)
                return;

            if (ownerAnimation.CurrentState == State.Walking)
                return; 

            ownerAnimation.PlayAnimation(State.Special, ownerAnimation.CurrentDirection);
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            var animation = GetComponent<Animation>(ComponentType.Animation);
            if (sprite != null && animation != null)
            {
                sprite.Teleport(ownerSprite.Position);
                animation.PlayAnimation(State.Walking, ownerAnimation.CurrentDirection, forceReset:true);
                animation.LockDirection = true; 
            }
            Active = true;
            _counter = 0; 
        }

        public override void LoadContent(Equipment owner, ContentManager content, ManagerMap managerMap, ManagerCamera managerCamera)
        {
            base.LoadContent(owner, content, managerMap, managerCamera);
            AddComponent(new Sprite(ManagerContent.LoadTexture("sword"), 16, 16, new Vector2(0, 0)));
            AddComponent(new Animation(16,16,2,100));
            AddComponent(new Camera(managerCamera));
        }

        public override void Update(double gameTime)
        {
            base.Update(gameTime);

            var animation = GetComponent<Animation>(ComponentType.Animation); 
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            _counter += gameTime;
            if (_counter > 250)
            {
                Active = false;
                animation.LockDirection = false; 
            }

            UpdateAnimation(gameTime,animation, sprite);
            UpdateCollision(animation, sprite); 

        }

        private void UpdateCollision(Animation animation,Sprite sprite)
        {
            Animation outAnimation;
            BaseObject outBaseObject; 
            if (_entities.CheckCollision(sprite.Rectangle, out outAnimation, out outBaseObject, Owner.GetOwnerId()))
            {
                var damage = outBaseObject.GetComponent<Damage>(ComponentType.Damage); 
                if(damage != null)
                    damage.TakingDamage(animation.CurrentDirection,1);
            }
        }

        private void UpdateAnimation(double gameTime, Animation animation, Sprite sprite)
        {
            var ownerAnimation = Owner.GetComponent<Animation>(ComponentType.Animation);
            //animation.ResetCounter(State.Walking,ownerAnimation.CurrentDirection);

            var ownerSprite = Owner.GetComponent<Sprite>(ComponentType.Sprite);

            if (ownerAnimation.CurrentState == State.Walking)
            {
                Active = false;
                animation.LockDirection = false;
            }


            if (_counter < 90)
            {
                switch (animation.CurrentDirection)
                {
                    case Direction.Left:
                        sprite.Teleport(new Vector2(ownerSprite.Position.X - sprite.Width + 5,
                            ownerSprite.Position.Y - sprite.Height));
                        break;
                    case Direction.Right:
                        sprite.Teleport(new Vector2(ownerSprite.Position.X + sprite.Width - 5,
                            ownerSprite.Position.Y - sprite.Height));
                        break;
                    case Direction.Up:
                        sprite.Teleport(new Vector2(ownerSprite.Position.X + sprite.Width - 5,
                            ownerSprite.Position.Y - sprite.Height + 5));
                        break;
                    case Direction.Down:
                        sprite.Teleport(new Vector2(ownerSprite.Position.X - sprite.Width + 5,
                            ownerSprite.Position.Y + sprite.Height - 5));
                        break;
                }
            }
            else
            {
                switch (animation.CurrentDirection)
                {
                    case Direction.Left:
                        sprite.Teleport(new Vector2(ownerSprite.Position.X - sprite.Width + 2,
                            ownerSprite.Position.Y));
                        break;
                    case Direction.Right:
                        sprite.Teleport(new Vector2(ownerSprite.Position.X + sprite.Width - 2,
                            ownerSprite.Position.Y));
                        break;

                    case Direction.Up:
                        sprite.Teleport(new Vector2(ownerSprite.Position.X,
                            ownerSprite.Position.Y - sprite.Height + 6));
                        break;
                    case Direction.Down:
                        sprite.Teleport(new Vector2(ownerSprite.Position.X + 4,
                            ownerSprite.Position.Y + sprite.Height - 6));
                        break;
                }


            }
        }
    }
}
