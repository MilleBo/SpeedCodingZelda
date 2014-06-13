using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Components.Items;
using LetsCreateZelda.Manager;
using LetsCreateZelda.Map;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components
{
    class Equipment : Component
    {
        private List<Item> _items;
        private Dictionary<ItemSlot, Item> _equipedItem; 
        private ContentManager _content;
        private ManagerMap _managerMap;
        private ManagerCamera _managerCamera;
        private Entities _entities;

        public override ComponentType ComponentType
        {
            get { return ComponentType.Items; }
        }

        public Equipment(ContentManager content, ManagerMap managerMap, ManagerCamera managerCamera, Entities entities)
        {
            _items = new List<Item>();
            _content = content; 
            _equipedItem = new Dictionary<ItemSlot, Item>();
            _managerMap = managerMap;
            _managerCamera = managerCamera;
            _entities = entities; 
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            item.LoadContent(this, _content,_managerMap,_managerCamera, _entities);
        }

        public void EquipItemInSlot(int id, ItemSlot itemSlot)
        {
            var item = _items.FirstOrDefault(i => i.ItemId == id); 
            if(item != null)
            {
                if (_equipedItem.ContainsKey(itemSlot))
                    _equipedItem[itemSlot] = item; 
                else 
                    _equipedItem.Add(itemSlot,item);
            }
        }

        public void FireItem(ItemSlot itemSlot)
        {
            if(_equipedItem.ContainsKey(itemSlot))
            {
                if(!_equipedItem[itemSlot].Active)
                    _equipedItem[itemSlot].Action();
            }
        }

        public override void Update(double gameTime)
        {
            foreach (var item in _equipedItem)
            {
                if(item.Value.Active)
                    item.Value.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            foreach (var item in _equipedItem)
            {
                if (item.Value.Active)
                    item.Value.Draw(spritebatch);
            }
        }
    }
}
