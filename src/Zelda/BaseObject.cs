using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda
{
    public class BaseObject
    {
        private readonly List<Component> _components;

        public BaseObject()
        {
            _components = new List<Component>();
            Kill = false;
            Hostile = true;
        }

        public string Id { get; set; }

        public bool Kill { get; set; }

        public bool Hostile { get; set; }

        public TComponentType GetComponent<TComponentType>()
            where TComponentType : Component
        {
            return _components.FirstOrDefault(c => c is TComponentType) as TComponentType;
        }

        public void AddComponent(Component component)
        {
            _components.Add(component);
            component.Initialize(this);
        }

        public void AddComponent(List<Component> components)
        {
            _components.AddRange(components);
            foreach (var component in components)
            {
                component.Initialize(this);
            }
        }

        public void RemoveComponent(Component component)
        {
            _components.Remove(component);
        }

        public virtual void Update(double gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                component.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
            _components?.ForEach(c => c.Initialize());
        }

        public void Uninitialize()
        {
            _components?.ForEach(c => c.Uninitalize());
        }
    }
}