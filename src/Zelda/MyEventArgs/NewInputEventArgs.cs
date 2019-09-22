using System;

namespace Zelda.MyEventArgs
{
    public class NewInputEventArgs : EventArgs
    {
        public NewInputEventArgs(Input input)
        {
            Input = input;
        }

        public Input Input { get; set; }
    }
}