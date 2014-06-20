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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.GameEvent
{
    interface IGameEvent
    {
        bool Done { get; set; }
        GameEventType EventType { get; }
        void Initialize();
        void Update(double gameTime);      
        void Draw(SpriteBatch spriteBatch);
    }
}

