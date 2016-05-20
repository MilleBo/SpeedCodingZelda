using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP.Components.Interaction
{
    class BlockPush : Component
    {
        private readonly BaseObject _player;
        private enum Phase { Waiting, Moving}

        private Phase _currentPhase;
        private Direction _direction;
        private int _moveCounter;
        private double _collisionCounter;
        private float _moveX;
        private float _moveY;

        public BlockPush(BaseObject player)
        {
            _player = player;
            _currentPhase = Phase.Waiting;
        }

        public override void Update(double gameTime)
        {
            var sprite = GetComponent<Sprite>();
            var collision = GetComponent<Collision>();
            var playerSprite = _player.GetComponent<Sprite>();
            var playerAnimation = _player.GetComponent<Animation>();

            if (sprite == null || playerSprite == null || playerAnimation == null || collision == null)
                return; 

            switch (_currentPhase)
            {
                case Phase.Waiting:
                    if (sprite.Rectangle.Intersects(playerSprite.Rectangle))
                    {
                        _collisionCounter += gameTime;
                        if (_collisionCounter > 1500)
                        {
                            _moveX = 0;
                            _moveY = 0;
                            switch (playerAnimation.CurrentDirection)
                            {
                                case Direction.Left:
                                    _moveX = -16;
                                    break;
                                case Direction.Right:
                                    _moveX = 16;
                                    break;
                                case Direction.Up:
                                    _moveY = -16;
                                    break;
                                case Direction.Down:
                                    _moveY = 16;
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            if (collision.CheckCollisionWithTiles(new Rectangle((int) (sprite.Position.X + _moveX),
                                (int) (sprite.Position.Y + _moveY), sprite.Width, sprite.Height)))
                            {
                                _collisionCounter = 0;
                                return;
                            }
                            else
                            {
                                _currentPhase = Phase.Moving;
                                _moveCounter = 16; 
                            }

                        }
                    }
                    else
                    {
                        _collisionCounter = 0; 
                    }
                    break;
                case Phase.Moving:
                    if (_moveCounter > 0)
                    {
                        sprite.Move(_moveX/32, _moveY/32);
                        _moveCounter--;
                    }
                    else
                    {
                        _currentPhase = Phase.Waiting;
                        _collisionCounter = 0; 
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            
        }
    }
}
