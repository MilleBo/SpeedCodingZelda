//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using LetsCreateZelda.UWP.Gui;
using LetsCreateZelda.UWP.Manager;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP.GameEvent
{
    class GameEventMessage : IGameEvent
    {
        public bool Done { get; set; }
        public string Text { get; private set; }

        public GameEventType EventType => GameEventType.Message;

        public GameEventMessage(string text)
        {
            Text = text; 
        }

        public void Initialize()
        {
            var window = new WindowMessage(Text);
            ManagerWindow.NewWindow("gameEventMessage",window);
            ManagerInput.ThrottleInput = true; 
            Done = false; 
        }

        public void Update(double gameTime)
        {
            if (!ManagerWindow.Contains("gameEventMessage"))
            {
                Done = true;
                ManagerInput.ThrottleInput = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}

