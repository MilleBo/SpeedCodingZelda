using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Zelda.Manager
{
    public class ManagerPlayer
    {
        public ManagerPlayer()
        {
            ExploredMapTiles = new List<Vector2>();
        }

        public List<Vector2> ExploredMapTiles { get; }

        public void UpdateMap(int x, int y)
        {
            if (!TileExplored(x, y))
            {
                ExploredMapTiles.Add(new Vector2(x, y));
            }
        }

        public bool TileExplored(int x, int y)
        {
            return ExploredMapTiles.Any(p => p.X == x && p.Y == y);
        }
    }
}
