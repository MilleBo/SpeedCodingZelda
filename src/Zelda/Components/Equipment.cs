//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Components.Items;
using Zelda.Manager;
using Zelda.Map;

namespace Zelda.Components
{
    class Equipment : Component
    {
        private List<Item> _items;
        private Dictionary<ItemSlot, Item> _equipedItem; 
        private ContentManager _content;
        private ManagerMap _managerMap;
        private ManagerCamera _managerCamera;
        private Entities _entities;

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

                item.MenuPosition = new Vector2(-1,-1);
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

        public void DrawGui(SpriteBatch spriteBatch, ItemSlot itemSlot, Rectangle rectangle)
        {
            if(_equipedItem.ContainsKey(itemSlot))
                _equipedItem[itemSlot].DrawGui(spriteBatch, rectangle);
        }

        public bool EquipedInSlot(ItemSlot itemSlot)
        {
            if(_equipedItem.ContainsKey(itemSlot))
                return _equipedItem[itemSlot] != null;
            return false; 
        }

        public void UnEquipInSlot(ItemSlot itemSlot, Vector2 cursorPosition)
        {
            if (_equipedItem.ContainsKey(itemSlot))
            {
                _equipedItem[itemSlot].MenuPosition = cursorPosition;
                _equipedItem.Remove(itemSlot);   
            }
            
        }

        public void DrawMenuGui(SpriteBatch spriteBatch)
        {
            foreach (var item in _items)
            {
                if(_equipedItem.ContainsValue(item))
                    continue;
                item.DrawMenu(spriteBatch);
            }
        }

        public void SwitchEquipment(ItemSlot itemSlot, Vector2 cursorPosition)
        {
            var item = _items.FirstOrDefault(i => i.MenuPosition.Equals(cursorPosition));
            UnEquipInSlot(itemSlot,cursorPosition);
            if (item != null)
            {
                _equipedItem.Add(itemSlot,item);
            }

        }
    }
}
