//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - https://www.youtube.com/user/Maloooon
//------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Screens
{
    public abstract class Screen
    {
        protected ManagerScreen ManagerScreen; 

        public Screen(ManagerScreen managerScreen)
        {
            ManagerScreen = managerScreen; 
        }

        public virtual void Initialize() {}
        public virtual void Uninitialize() {}
        public abstract void LoadContent(ContentManager content);
        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch); 
    }
}


