using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LetsCreateZelda.Manager
{
    class ManagerPlayer
    {
        public List<Vector2> ExploredMapTiles { get; private set;  }

        public ManagerPlayer()
        {
            ExploredMapTiles = new List<Vector2>( );
        }

        public void UpdateMap(float x, float y)
        {
            if (!ExploredMapTiles.Any(p => p.X == (int)x && p.Y == (int)y))
            {
                ExploredMapTiles.Add(new Vector2((int)x,(int)y));
            }
        }
    }
}
