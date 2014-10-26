//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - https://www.youtube.com/user/Maloooon
//------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Components.StatusEffects;
using LetsCreateZelda.Manager;
using LetsCreateZelda.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components.Items
{
    internal class Boomerang : Item
    {
        private readonly Entities _entities;
        private Direction _currentDirection;
        private double _counter;
        private float _speed;
        private bool _alreadyHitObject; 
        private enum BoomerangState
        {
            Forward,
            Back,
            Stop
        };
        private BoomerangState _currentState;

        public Boomerang(Entities entities)
        {
            _entities = entities;
            ItemId = 1;
            _speed = 2.5f; 
            MenuPosition = new Vector2(0,0);
            _alreadyHitObject = false; 
        }

        public override void Action()
        {
            var ownerAnimation = Owner.GetComponent<Animation>(ComponentType.Animation);
            var ownerSprite = Owner.GetComponent<Sprite>(ComponentType.Sprite); 
            if (ownerAnimation == null || ownerSprite == null)
                return;
            ownerAnimation.PlayAnimation(State.Special, ownerAnimation.CurrentDirection);
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            var animation = GetComponent<Animation>(ComponentType.Animation);
            if(sprite != null && animation != null)
            {
                sprite.Teleport(ownerSprite.Position);
                animation.CurrentDirection = Direction.Down;
                animation.LockDirection = true; 
            }
            _currentDirection = ownerAnimation.CurrentDirection; 
            _currentState = BoomerangState.Forward;
            Active = true;
            _counter = 0;
        }

        public override void LoadContent(Equipment owner, ContentManager content, ManagerMap managerMap, ManagerCamera managerCamera, Entities entities)
        {
            base.LoadContent(owner,content,managerMap,managerCamera,entities);
            AddComponent(new Sprite(ManagerContent.LoadTexture("boomerang"),16,16,new Vector2(0,0)));
            AddComponent(new Collision(managerMap,entities));
            AddComponent(new Animation(16,16,3));
            AddComponent(new Camera(managerCamera));
            GuiTexture = ManagerContent.LoadTexture("boomerang_gui"); 
        }

        public override void Update(double gameTime)
        {
            base.Update(gameTime);

            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            if (sprite == null)
            {
                _currentState = BoomerangState.Stop;
                return;
            }

            _counter += gameTime; 

            CheckCollision();

            switch (_currentState)
            {
                    case BoomerangState.Forward:
                        MoveForward(sprite);
                        if(_counter > 300)
                            _currentState = BoomerangState.Back;
                    break;

                    case BoomerangState.Back:
                        MoveBack(sprite); 
                    break; 
            }
        }


        private void CheckCollision()
        {
            BaseObject outBaseObject;
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            Animation outAnimation;
            if (_entities.CheckCollision(sprite.Rectangle, out outAnimation, out outBaseObject, Owner.GetOwnerId()))
            {
                var statusEffect = outBaseObject.GetComponent<StatusEffect>(ComponentType.StatusEffects);
                statusEffect.StatusEffects.Add(new StatusEffectFreeze(outBaseObject));

                _currentState = BoomerangState.Back;
                _counter = 0;
                _alreadyHitObject = true; 
            }
        }


        private void MoveBack(Sprite sprite)
        {
            var ownerSprite = Owner.GetComponent<Sprite>(ComponentType.Sprite); 
            if(ownerSprite == null)
            {
                _currentState = BoomerangState.Stop;
                Active = false; 
            }

            if(ManagerFunction.Distance(sprite.Position,ownerSprite.Position) < 2)
            {
                _currentState = BoomerangState.Stop;
                Active = false;
                return; 
            }

            if(ownerSprite.Position.X < sprite.Position.X)
                sprite.Move(-1*_speed,0);
            if (ownerSprite.Position.X > sprite.Position.X)
                sprite.Move(_speed, 0);
            if (ownerSprite.Position.Y < sprite.Position.Y)
                sprite.Move(0, -1*_speed);
            if (ownerSprite.Position.Y > sprite.Position.Y)
                sprite.Move(0, _speed);
        }

        private void MoveForward(Sprite sprite)
        {
            var x = 0f;
            var y = 0f;

            switch (_currentDirection)
            {
                case Direction.Up:
                    y = -1*_speed;
                    break;

                case Direction.Down:
                    y = _speed;
                    break;

                case Direction.Left:
                    x = -1*_speed;
                    break;

                case Direction.Right:
                    x = _speed;
                    break;
                default:
                    return;

            }

            if (_currentState == BoomerangState.Forward)
            {
                var collision = GetComponent<Collision>(ComponentType.Collision);
                if(collision != null && collision.CheckCollisionWithTiles(new Rectangle((int) (sprite.Position.X + x), (int) (sprite.Position.Y + y),sprite.Width,sprite.Height)))
                {
                    _currentState = BoomerangState.Back;
                    _counter = 0; 
                }
                else
                {
                    sprite.Move(x,y);
                }
            }
        }
    }
}



