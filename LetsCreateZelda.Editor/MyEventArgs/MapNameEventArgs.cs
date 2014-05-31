using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsCreateZelda.Editor.MyEventArgs
{
    public class MapNameEventArgs : EventArgs
    {
        public string MapName { get; set; }

        public MapNameEventArgs(string mapName)
        {
            MapName = mapName; 
        }
    }
}
