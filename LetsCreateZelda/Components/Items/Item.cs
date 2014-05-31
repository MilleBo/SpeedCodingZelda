using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components.Items
{
    abstract class Item : BaseObject
    {

        protected Equipment Owner;
        public int ItemId { get; set; }
        public bool Active { get; set; }

        public abstract void Action();
        public virtual void LoadContent(Equipment owner, ContentManager content, ManagerMap managerMap, ManagerCamera managerCamera)
        {
            Owner = owner; 
        }
    }
}
