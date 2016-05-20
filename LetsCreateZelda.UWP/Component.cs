//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP
{
    public abstract class Component
    {
        private BaseObject _baseObject;

        public void Initialize(BaseObject baseObject)
        { 
            _baseObject = baseObject; 
        }

        public string GetOwnerId()
        {
            if (_baseObject == null)
                return ""; 
            return _baseObject.Id; 
        }

        public void RemoveMe()
        {
            _baseObject.RemoveComponent(this);
        }

        public void KillBaseObject()
        {
            _baseObject.Kill = true; 
        }

        public TComponentType GetComponent<TComponentType>() where TComponentType : Component
        {
            return _baseObject?.GetComponent<TComponentType>();
        }

        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spritebatch);

        public virtual void Initialize() { }

        public virtual void Uninitalize() { }

    }
}



