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
using Microsoft.Xna.Framework.Graphics;
using OpenTK.Graphics.ES20;

namespace LetsCreateZelda.Components
{
    public class Animation : Component
    {
        public override ComponentType ComponentType
        {
            get { return ComponentType.Animation; }
        }

        private int _width;
        private int _height;
        public Rectangle TextureRectangle { get; private set; }
        public bool LockDirection { get; set; }
        public bool LockAnimation { get; set; }

        public Direction CurrentDirection;
        public State CurrentState { get; private set; }
        private double _counter;
        public int AnimationIndex { get; private set; }
        private int _animationFrames;
        private int _animationSpeed;

        private bool _loop;
        private int _count;
        private int _current; 

        public Animation(int width, int height, int animationFrames = 1, int animationSpeed = 200) 
        {
            _width = width;
            _height = height;
            _counter = 0;
            AnimationIndex = 0;
            CurrentState = State.Standing;
            _animationFrames = animationFrames;
            _animationSpeed = animationSpeed; 
            TextureRectangle = new Rectangle(0,0,width,height);
        }


        public override void Update(double gameTime)
        {
            if (LockAnimation)
                return;

            if (!_loop && _current > _count - 1)
            {
                CurrentState = State.Standing;
                return;
            }

            _counter += gameTime;
            if (_counter > _animationSpeed)
            {
                switch (CurrentState)
                {
                    case State.Walking:
                        ChangeState(0, _animationFrames);
                        _counter = 0;
                        break;
                    case State.Special:
                        ChangeState(_height * 4, 1);
                        _counter = 0;
                        break;
                    case State.Pushing:
                        ChangeState(_height * 8);
                        _counter = 0; 
                        break;
                }
            }
        }

        public void PlayAnimation(State state, Direction direction, int count = 1, bool loop = false, bool forceReset = false)
        {
            if((CurrentDirection != direction && !LockDirection) || forceReset)
            {
                _counter = 1000;
                AnimationIndex = 0;
            }

            CurrentState = state;
            if(!LockDirection)
                CurrentDirection = direction;
            _count = count;
            _current = 0; 
            _loop = loop; 
        }

        public void StopAnimation()
        {
            _current = _count + 1;
            _loop = false; 
        }

        private void ChangeState(int y = 0, int animationFrames = 2)
        {
            if (AnimationIndex + 1 > animationFrames)
            {
                AnimationIndex = 0;
                _current++; 
            }

            switch (CurrentDirection)
            {
                case Direction.Down:
                    TextureRectangle = new Rectangle(_width * AnimationIndex, y, _width, _height);
                    break;
                case Direction.Up:
                    TextureRectangle = new Rectangle(_width * AnimationIndex, y + _height, _width, _height);
                    break;
                case Direction.Left:
                    TextureRectangle = new Rectangle(_width * AnimationIndex, y +_height * 2, _width, _height);
                    break;
                case Direction.Right:
                    TextureRectangle = new Rectangle(_width * AnimationIndex, y + _height * 3, _width, _height);
                    break;
            }


            if (AnimationIndex + 1 <= animationFrames)
                AnimationIndex++; 
                           
        }

        public override void Draw(SpriteBatch spritebatch)
        {

        }

    }
}





