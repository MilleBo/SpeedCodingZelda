using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Zelda.Manager
{
    public class ManagerCamera
    {
        private readonly float _speed;
        private Vector2 _moveToPosition;

        public ManagerCamera()
        {
            _speed = 5f;
            Position = new Vector2(0, 0);
        }

        public bool Locked => (int)Position.X != (int)_moveToPosition.X || (int)Position.Y != (int)_moveToPosition.Y;

        public Vector2 Position { get; set; }

        public Vector2 TilePosition => new Vector2(Position.X / 160, Position.Y / 120);

        public void Update(double gameTime)
        {
            if (!Locked)
            {
                return;
            }

            if (Position.X < _moveToPosition.X)
            {
                Position = new Vector2(Position.X + _speed, Position.Y);
            }

            if (Position.X > _moveToPosition.X)
            {
                Position = new Vector2(Position.X - _speed, Position.Y);
            }

            if (Position.Y > _moveToPosition.Y)
            {
                Position = new Vector2(Position.X, Position.Y - _speed);
            }

            if (Position.Y < _moveToPosition.Y)
            {
                Position = new Vector2(Position.X, Position.Y + _speed);
            }

            if (ManagerFunction.Distance(Position, _moveToPosition) < 5)
            {
                Position = _moveToPosition;
            }
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
               case Direction.Left:
                    _moveToPosition = new Vector2(Position.X - 160, Position.Y);
                    break;
               case Direction.Right:
                    _moveToPosition = new Vector2(Position.X + 160, Position.Y);
                    break;
               case Direction.Up:
                    _moveToPosition = new Vector2(Position.X, Position.Y - 128);
                    break;
               case Direction.Down:
                    _moveToPosition = new Vector2(Position.X, Position.Y + 128);
                    break;
            }
        }

        public bool InScreenCheck(Vector2 vector)
        {
            return (vector.X > Position.X - 16 && vector.X < Position.X + 160 + 16) && (vector.Y > Position.Y - 16 && vector.Y < Position.Y + 128 + 16);
        }

        public Vector2 WorldToScreenPosition(Vector2 position)
        {
            return new Vector2(position.X - Position.X, position.Y - Position.Y);
        }

        public bool MouseInsideWindow()
        {
            var state = Mouse.GetState();
            var pos = new Point(state.X, state.Y);
            return pos.X >= 0 && pos.X <= 160 && pos.Y >= 0 && pos.Y <= 128;
        }
    }
}
