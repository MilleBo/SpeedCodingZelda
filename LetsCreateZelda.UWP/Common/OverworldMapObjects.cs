using System.Collections.Generic;
using LetsCreateZelda.UWP.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP.Common
{
    class OverworldMapObjects
    {
        private Dictionary<Vector2, Texture2D> _objects;
        private Texture2D _mapIconDungeonTexture;
        private Texture2D _mapIconOwlTexture;
        private Texture2D _mapIconQuestionTexture;
        private Texture2D _mapIconShopTexture; 

        public OverworldMapObjects()
        {
            _objects = new Dictionary<Vector2, Texture2D>();
        }

        public void LoadContent(ContentManager content)
        {
            _mapIconDungeonTexture = ManagerContent.LoadTexture("map_icon_dungeon");
            _mapIconOwlTexture = ManagerContent.LoadTexture("map_icon_owl");
            _mapIconQuestionTexture = ManagerContent.LoadTexture("map_icon_question");
            _mapIconShopTexture = ManagerContent.LoadTexture("map_icon_shop");

            _objects.Add(new Vector2(0,1), _mapIconDungeonTexture);
            _objects.Add(new Vector2(1,2),  _mapIconOwlTexture );
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cursorPosition)
        {
            var key = new Vector2((int) cursorPosition.X, (int) cursorPosition.Y);
            if (_objects.ContainsKey(key))
            {
                spriteBatch.Draw(_objects[key],new Rectangle(100,100,30,30),Color.White);
            }
        }


    }
}
