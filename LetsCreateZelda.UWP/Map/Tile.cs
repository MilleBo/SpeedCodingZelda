//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using LetsCreateZelda.UWP.Manager;
using Microsoft.Xna.Framework;

namespace LetsCreateZelda.UWP.Map
{
    public class Tile
    {
        protected const int Width = 16;
        protected const int Height = 16;

        public int XPos { get; set; }
        public int YPos { get; set; }

        public Rectangle Rectangle => new Rectangle(XPos * 16, YPos * 16, 16, 16);
        public ManagerCamera ManagerCamera { get; set; }

        public Vector2 Position => new Vector2(XPos * 16, YPos * 16);
    }
}




