using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsCreateZelda.MyEventArgs
{
    public class NewInputEventArgs : EventArgs
    {
        public Input Input { get; set; }

        public NewInputEventArgs(Input input)
        {
            Input = input; 
        }
    }
}
