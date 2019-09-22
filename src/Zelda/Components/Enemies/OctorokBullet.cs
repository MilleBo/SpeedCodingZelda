using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Components.Enemies
{
    public class OctorokBullet
    {
        private readonly Sprite _sprite;
        private readonly Collision _collision;
        private readonly Direction _direction;
        private readonly float _speed;
        private BaseObject _player;

        public OctorokBullet(Sprite sprite, Collision collision, BaseObject player, Direction direction)
        {
            _sprite = sprite;
            _player = player;
            _direction = direction;
            _speed = 1.5f;
            _collision = collision;
        }

        public bool Dead { get; private set; }

        public void Update(double gameTime)
        {
            switch (_direction)
            {
                case Direction.Up:
                    _sprite.Move(0, -_speed);
                    break;

                case Direction.Down:
                    _sprite.Move(0, _speed);
                    break;

                case Direction.Left:
                    _sprite.Move(-_speed, 0);
                    break;

                case Direction.Right:
                    _sprite.Move(_speed, 0);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_collision.CheckCollisionWithTiles(
                new Rectangle((int)_sprite.Position.X, (int)_sprite.Position.Y, _sprite.Width, _sprite.Height),
                false))
            {
                Dead = true;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            _sprite.Draw(spritebatch);
        }
    }
}