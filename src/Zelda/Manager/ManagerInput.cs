using System;
using Microsoft.Xna.Framework.Input;
using Zelda.MyEventArgs;

namespace Zelda.Manager
{
    public class ManagerInput
    {
        private static double _pauseCounter;
        private static bool _pause;
        private static double _pauseTime;
        private static double _cooldown;

        private KeyboardState _keyState;
        private KeyboardState _lastKeyState;
        private Keys _lastKey;
        private double _counter;

        public ManagerInput()
        {
            ThrottleInput = false;
            LockMovement = false;
            _counter = 0;
        }

        public static event EventHandler<NewInputEventArgs> FireNewInput;

        public static bool ThrottleInput { get; set; }

        public static bool LockMovement { get; set; }

        public static void PauseInput(double milisecond)
        {
            _pauseCounter = 0;
            _pauseTime = milisecond;
            _pause = true;
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

            if (_cooldown > 0)
            {
                _counter += gameTime;
                if (_counter > gameTime)
                {
                    _cooldown = 0;
                    _counter = 0;
                }
                else
                {
                    return;
                }
            }

            ComputerControlls(gameTime);
        }

        public void ComputerControlls(double gameTime)
        {
            _keyState = Keyboard.GetState();
            if (_keyState.IsKeyUp(_lastKey) && _lastKey != Keys.None)
            {
                FireNewInput?.Invoke(this, new NewInputEventArgs(Input.None));
            }

            CheckKeyState(Keys.Left, Input.Left);
            CheckKeyState(Keys.Right, Input.Right);
            CheckKeyState(Keys.Up, Input.Up);
            CheckKeyState(Keys.Down, Input.Down);
            CheckKeyState(Keys.Enter, Input.Enter);
            CheckKeyState(Keys.A, Input.A);
            CheckKeyState(Keys.S, Input.S);
            CheckKeyState(Keys.RightShift, Input.Select);
            CheckKeyState(Keys.Enter, Input.Start);

            _lastKeyState = _keyState;
        }

        private void CheckKeyState(Keys key, Input fireInput)
        {
            if (_keyState.IsKeyDown(key))
            {
                if (!ThrottleInput || (ThrottleInput && _lastKeyState.IsKeyUp(key)))
                {
                    if (FireNewInput != null)
                    {
                        FireNewInput(this, new NewInputEventArgs(fireInput));
                        _lastKey = key;
                    }
                }
            }
        }
    }
}