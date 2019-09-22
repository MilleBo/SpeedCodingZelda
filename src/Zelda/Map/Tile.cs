using Microsoft.Xna.Framework;
using Zelda.Manager;

namespace Zelda.Map
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
