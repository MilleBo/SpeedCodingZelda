using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;

namespace Zelda.Components.Movement
{
    public class AIMovementRandom : Component
    {
        private readonly int _frequency;
        private Direction _currentDirection;
        private double _counter;

        public AIMovementRandom(int frequency)
        {
            _frequency = frequency;
            ChangeDirection();
        }

        public override void Update(double gameTime)
        {
            var sprite = GetComponent<Sprite>();
            if (sprite == null)
            {
                return;
            }

            var camera = GetComponent<Camera>();
            if (camera == null)
            {
                return;
            }

            if (!camera.InsideScreen(sprite.Position) || camera.CameraInTransition())
            {
                return;
            }

            var stats = GetComponent<Stats>();
            var speed = 1.5f;
            if (stats != null)
            {
                speed = stats.Speed;
            }

            _counter += gameTime;
            if (_counter > _frequency)
            {
                ChangeDirection();
            }

            var collision = GetComponent<Collision>();
            var x = 0f;
            var y = 0f;

            switch (_currentDirection)
            {
                case Direction.Up:
                    y = -1 * speed;
                    break;

                case Direction.Down:
                    y = speed;
                    break;

                case Direction.Left:
                    x = -1 * speed;
                    break;

                case Direction.Right:
                    x = speed;
                    break;
                default:
                    return;
            }

            if (collision.CheckCollisionWithTiles(new Rectangle(
                (int)(sprite.Position.X + x),
                (int)(sprite.Position.Y + y),
                sprite.Width,
                sprite.Height)))
            {
                ChangeDirection();
                return;
            }

            sprite.Move(x, y);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
        }

        private void ChangeDirection()
        {
            _counter = 0;
            _currentDirection = (Direction)ManagerFunction.Random(0, 3);
        }
    }
}