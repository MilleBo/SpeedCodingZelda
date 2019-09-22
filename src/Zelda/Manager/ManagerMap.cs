//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameEvent;
using Zelda.Map;

namespace Zelda.Manager
{
    public class ManagerMap
    {
        private List<TileGraphic> _tiles;
        private List<TileCollision> _tileCollisions;
        private List<TileEvent> _tileEvents;  
        private string _mapName;
        private ManagerCamera _managerCamera; 

        public ManagerMap(string mapName, ManagerCamera managerCamera)
        {
            _tiles = new List<TileGraphic>();
            _tileCollisions = new List<TileCollision>();
            _tileEvents = new List<TileEvent>();
            _mapName = mapName;
            _managerCamera = managerCamera; 
        }

        public void LoadContent()
        {
            var tiles = new List<TileGraphic>(); 
            XMLSerialization.LoadXML(out tiles, string.Format("Content\\Maps\\{0}\\{0}_tiles.map", _mapName)); 
            if(tiles != null)
            {
                _tiles = tiles; 
                _tiles.Sort((n,i) => n.ZPos > i.ZPos ? 1 : 0);
                foreach (var tile in _tiles)
                {
                    tile.LoadContent();
                    tile.ManagerCamera = _managerCamera; 
                }
            }

            var tilesCollision = new List<TileCollision>();
            XMLSerialization.LoadXML(out tilesCollision, string.Format("Content\\Maps\\{0}\\{0}_collision.map", _mapName));
            if(tilesCollision != null)
            {
                _tileCollisions = tilesCollision; 
                _tileCollisions.ForEach(t => t.ManagerCamera = _managerCamera);
            }

            //Just for test 
            var dictionary = new Dictionary<int, List<IGameEvent>>(); 
            dictionary.Add(0,new List<IGameEvent> { new GameEventMessage("I start tile events with id 1"), new GameEventSwitch(1, true)});
            _tileEvents.Add(new TileEvent(1, 1, dictionary));

            var dictionary2 = new Dictionary<int, List<IGameEvent>>(); 
            dictionary2.Add(1, new List<IGameEvent>() { new GameEventMessage("Hello! I'm tile event with id 1")});
            _tileEvents.Add(new TileEvent(1, 5, dictionary2));

            _tileEvents[0].ManagerCamera = _managerCamera;
            _tileEvents[1].ManagerCamera = _managerCamera; 
        }

        public void Update(double gameTime)
        {
            foreach (var tile in _tiles)
            {
                tile.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in _tiles)
            {
                tile.Draw(spriteBatch);
            }
        }

        public void DrawCollision(SpriteBatch spriteBatch)
        {
            foreach (var tileCollision in _tileCollisions)
            {
                tileCollision.Draw(spriteBatch);
            }
        }

        public void AddTile(TileGraphic tile)
        {
            if (_tiles.Any(t => t.XPos == tile.XPos && t.YPos == tile.YPos))
            {
                //Remove the old one 
                var oldTile = _tiles.FirstOrDefault(t => t.XPos == tile.XPos && t.YPos == tile.YPos);
                _tiles.Remove(oldTile);
            }

            _tiles.Add(tile);
        }

        public bool CheckCollision(Rectangle rectangle, string id = "")
        {
            var s = _tileCollisions.Any(tile => tile.Intersect(rectangle));
            if (!string.IsNullOrEmpty(id) && id.Equals("player"))
            {
                var t = _tileEvents.FirstOrDefault(tile => tile.Intersect(rectangle));
                if (t != null)
                {
                    t.StartEvent(); 
                }
            }

            return s; 
        }


        public void Save(string mapName)
        {
            XMLSerialization.SaveXML(_tiles, string.Format("Content/Maps/{0}/{0}_tiles.map", mapName));
            XMLSerialization.SaveXML(_tileCollisions, string.Format("Content/Maps/{0}/{0}_collision.map", mapName)); 
        }

        public void AddCollisionTile(TileCollision tileCollision)
        {
            if(!_tileCollisions.Any(t => t.XPos == tileCollision.XPos && t.YPos == tileCollision.YPos))
                _tileCollisions.Add(tileCollision);
        }

        public void LoadCollisionTexture()
        {
            _tileCollisions.ForEach(t => t.LoadContent());
        }
    }
}

