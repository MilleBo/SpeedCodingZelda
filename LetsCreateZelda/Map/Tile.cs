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
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework;

namespace LetsCreateZelda.Map
{
    public class Tile
    {
        protected const int Width = 16;
        protected const int Height = 16;

        public int XPos { get; set; }
        public int YPos { get; set; }

        public Rectangle Rectangle { get { return new Rectangle(XPos * 16, YPos * 16, 16, 16); } }
        public ManagerCamera ManagerCamera { get; set; }

        public Vector2 Position { get { return new Vector2(XPos * 16, YPos * 16); } }
    }
}




