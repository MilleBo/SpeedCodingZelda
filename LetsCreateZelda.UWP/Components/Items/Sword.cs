//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using LetsCreateZelda.UWP.Manager;
using LetsCreateZelda.UWP.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LetsCreateZelda.UWP.Components.Items
{
    class Sword : Item
    {
        private double _counter;
        private Entities _entities;

        public Sword(Entities entities)
        {
            ItemId = 2;
            _entities = entities;
            MenuPosition = new Vector2(0, 0);
        }

        public override void Action()
        {
            var ownerAnimation = Owner.GetComponent<Animation>();
            var ownerSprite = Owner.GetComponent<Sprite>();
            if (ownerAnimation == null || ownerSprite == null)
                return;

            if (ownerAnimation.CurrentState == State.Walking)
                return; 

            ownerAnimation.PlayAnimation(State.Special, ownerAnimation.CurrentDirection);
            var sprite = GetComponent<Sprite>();
            var animation = GetComponent<Animation>();
            if (sprite != null && animation != null)
            {
                sprite.Teleport(ownerSprite.Position);
                animation.PlayAnimation(State.Walking, ownerAnimation.CurrentDirection, forceReset:true);
                animation.LockDirection = true; 
            }
            Active = true;
            _counter = 0; 
        }

        public override void LoadContent(Equipment owner, ContentManager content, ManagerMap managerMap, ManagerCamera managerCamera, Entities entities)
        {
            base.LoadContent(owner, content, managerMap, managerCamera,entities);
            AddComponent(new Sprite(ManagerContent.LoadTexture("sword"), 16, 16, new Vector2(0, 0)));
            AddComponent(new Animation(16,16,2,100));
            AddComponent(new Camera(managerCamera));
            GuiTexture = ManagerContent.LoadTexture("sword_gui"); 
        }

        public override void Update(double gameTime)
        {
            base.Update(gameTime);

            var animation = GetComponent<Animation>(); 
            var sprite = GetComponent<Sprite>();
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
                var damage = outBaseObject.GetComponent<Damage>(); 
                if(damage != null)
                    damage.TakingDamage(animation.CurrentDirection,1);
            }
        }

        private void UpdateAnimation(double gameTime, Animation animation, Sprite sprite)
        {
            var ownerAnimation = Owner.GetComponent<Animation>();
            //animation.ResetCounter(State.Walking,ownerAnimation.CurrentDirection);

            var ownerSprite = Owner.GetComponent<Sprite>();

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





