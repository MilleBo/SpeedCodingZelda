using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenTK.Platform.Windows;


namespace LetsCreateZelda.Map
{
    class Entities
    {
        private List<BaseObject> _entities; 

        public Entities()
        {
            _entities = new List<BaseObject>();
        }

        public void AddEntity(BaseObject newObject)
        {
            _entities.Add(newObject);
        }

        public void Update(double gameTime)
        {
            var i = 0;
            while (i < _entities.Count)
            {
                    _entities[i].Update(gameTime);
                if (_entities[i].Kill)
                    _entities.RemoveAt(i);
                else
                    i++; 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var baseObject in _entities)
            {
                baseObject.Draw(spriteBatch);
            }
        }

        public bool CheckCollision(Rectangle rectangle, out Animation outAnimation, out BaseObject outBaseObject, string id)
        {
            outAnimation = null;
            outBaseObject = null; 


            foreach (var baseObject in _entities)
            {
                if(baseObject == null)
                    continue;

                if(baseObject.Id == id)
                    continue;
                
                var sprite = baseObject.GetComponent<Sprite>(ComponentType.Sprite); 
                if(sprite == null)
                    continue;
                if (sprite.Rectangle.Intersects(rectangle))
                {
                    outAnimation = baseObject.GetComponent<Animation>(ComponentType.Animation);
                    outBaseObject = baseObject; 
                    return true;
                }
            }
            return false; 
        }
    }
}
