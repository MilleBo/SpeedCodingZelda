//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP.GameEvent
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

