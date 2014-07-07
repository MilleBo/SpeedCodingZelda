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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LetsCreateZelda.Manager
{
    public class ManagerCamera
    {
        private Vector2 _position;
        private Direction _moveDirection;
        private Vector2 _moveToPosition;
        private float _speed;
        public bool Locked { get { return (int)_position.X != (int)_moveToPosition.X || (int)_position.Y != (int)_moveToPosition.Y; } }

        public Vector2 Position { get { return _position;  } }
        public Vector2 TilePosition { get { return new Vector2(_position.X/160, _position.Y/120);}}

        public ManagerCamera()
        {
            _speed = 5f; 
            _position = new Vector2(0,0);
        }

        public void Update(double gameTime)
        {
            if (!Locked)
                return;

            if (_position.X < _moveToPosition.X)
                _position.X += _speed;
            if (_position.X > _moveToPosition.X)
                _position.X -= _speed;
            if (_position.Y > _moveToPosition.Y)
                _position.Y -= _speed;
            if (_position.Y < _moveToPosition.Y)
                _position.Y += _speed; 

            if(ManagerFunction.Distance(_position,_moveToPosition) < 5)
            {
                _position = _moveToPosition; 
            }
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
               case Direction.Left:
                    _moveToPosition = new Vector2(_position.X - 160, _position.Y);
                    break; 
                case Direction.Right:
                    _moveToPosition = new Vector2(_position.X + 160, _position.Y);
                    break; 
                case Direction.Up:
                    _moveToPosition = new Vector2(_position.X, _position.Y - 128);
                    break; 

                case Direction.Down:
                    _moveToPosition = new Vector2(_position.X, _position.Y + 128);
                    break; 
            }
        }

        public bool InScreenCheck(Vector2 vector)
        {
            return ((vector.X > _position.X - 16 && vector.X < _position.X + 160 + 16) &&
                    (vector.Y > _position.Y - 16 && vector.Y < _position.Y + 128 + 16)); 
        }

        public Vector2 WorldToScreenPosition(Vector2 position)
        {
            return new Vector2(position.X - _position.X, position.Y - _position.Y);
        }


        public bool MouseInsideWindow()
        {
            var state = Mouse.GetState();
            var pos = new Point(state.X, state.Y);
            return pos.X >= 0 && pos.X <= 160 && pos.Y >= 0 && pos.Y <= 128;
        }
    }
}



