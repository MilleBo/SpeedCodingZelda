using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Zelda.Manager;

namespace Zelda.Gui
{
    public class WindowMessage : Window
    {
        private List<string> _text;
        private int _currentIndex;

        public WindowMessage(
            string text,
            WindowPosition position = WindowPosition.Down,
            bool slowText = false)
        {
            Height = 40;
            Width = 150;

            switch (position)
            {
                    case WindowPosition.Up:
                    Position = new Vector2(5, 5);
                    break;

                    case WindowPosition.Down:
                    Position = new Vector2(5, 85);
                    break;
            }

            SplitMessage(text);
        }

        public override void Update(double gameTime)
        {
        }

        public override void Reset()
        {
            Active = true;
            Done = false;
            _currentIndex = 0;
            ManagerInput.FireNewInput += ManagerInput_FireNewInput;
        }

        public override void DeInitialize()
        {
            ManagerInput.FireNewInput -= ManagerInput_FireNewInput;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (_currentIndex < _text.Count)
            {
                spriteBatch.DrawString(Font, _text[_currentIndex], new Vector2(Position.X + 5, Position.Y + 5), FontColor);
            }
        }

        private void ManagerInput_FireNewInput(object sender, MyEventArgs.NewInputEventArgs e)
        {
            if (Done || !Active || e.Input != Input.Enter)
            {
                return;
            }

            Done = true;
            Active = false;
        }

        private void SplitMessage(string text)
        {
            _text = new List<string>();
            if (Font.MeasureString(text).X > Width)
            {
                for (var n = Width / 5; n < text.Length; n += Width / 5)
                {
                    if (!char.IsWhiteSpace(text[n]))
                    {
                        n = FindSpace(text, n);
                    }

                    text = text.Remove(n, 1);
                    text = text.Insert(n, "\n");
                }

                _text.Add(text);
            }
            else
            {
                _text.Add(text);
            }
        }

        private int FindSpace(string text, int n)
        {
            for (int j = n; j > 0; j--)
            {
                var t = text[j];
                if (char.IsWhiteSpace(t))
                {
                    return j;
                }
            }

            return n;
        }
    }
}