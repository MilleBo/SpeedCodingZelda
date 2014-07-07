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
using LetsCreateZelda.MyEventArgs;
using Microsoft.Xna.Framework.Input;

namespace LetsCreateZelda.Manager
{
    public class ManagerInput
    {
        private KeyboardState _keyState;
        private KeyboardState _lastKeyState;
        private Keys _lastKey;
        private static event EventHandler<NewInputEventArgs> _FireNewInput;
        private double _counter;
        private static double _cooldown;
        private static double _pauseCounter;
        private static bool _pause;
        private static double _pauseTime; 
        

        public static event EventHandler<NewInputEventArgs> FireNewInput
        {
            add { _FireNewInput += value;  }
            remove { _FireNewInput -= value;  }
        }

        public static bool ThrottleInput { get; set; }
        public static bool LockMovement { get; set; }

        


        public ManagerInput()
        {
            ThrottleInput = false;
            LockMovement = false;
            _counter = 0;   
        }

        public void Update(double gameTime)
        {
            if (_pause)
            {
                _pauseCounter += gameTime;
                if (_pauseCounter > _pauseTime)
                {
                    _pause = false;
                }
                else
                {
                    return; 
                }
            }


            if(_cooldown > 0)
            {
                _counter += gameTime;
                if (_counter > gameTime)
                {
                    _cooldown = 0;
                    _counter = 0;
                }
                else
                    return; 
            }

            ComputerControlls(gameTime); 
        }


        public void ComputerControlls(double gameTime)
        {
            _keyState = Keyboard.GetState(); 
            if(_keyState.IsKeyUp(_lastKey) && _lastKey != Keys.None)
            {
                if(_FireNewInput != null)
                    _FireNewInput(this,new NewInputEventArgs(Input.None));
            }
            
            CheckKeyState(Keys.Left, Input.Left);
            CheckKeyState(Keys.Right, Input.Right);
            CheckKeyState(Keys.Up, Input.Up);
            CheckKeyState(Keys.Down, Input.Down);
            CheckKeyState(Keys.Enter, Input.Enter);
            CheckKeyState(Keys.A, Input.A);
            CheckKeyState(Keys.S,Input.S);
            CheckKeyState(Keys.RightShift,Input.Select);
            CheckKeyState(Keys.Enter, Input.Start);

            _lastKeyState = _keyState; 
        }

        private void CheckKeyState(Keys key, Input fireInput)
        {
            if(_keyState.IsKeyDown(key))
            {
                if(!ThrottleInput || (ThrottleInput && _lastKeyState.IsKeyUp(key)))
                {
                     if(_FireNewInput != null)
                     {
                         _FireNewInput(this, new NewInputEventArgs(fireInput));
                         _lastKey = key; 
                     }
                }
            }
        }

        public static void PauseInput(double milisecond)
        {
            _pauseCounter = 0;
            _pauseTime = milisecond;
            _pause = true; 
        }

    }
}



