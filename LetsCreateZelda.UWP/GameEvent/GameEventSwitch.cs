//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using LetsCreateZelda.UWP.Manager;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP.GameEvent
{
    class GameEventSwitch : IGameEvent
    {
        public bool Done { get; set; }
        public int EventSwitchId { get; set; }
        public bool Value { get; set; }
        public GameEventType EventType => GameEventType.EventSwitch;

        public GameEventSwitch(int eventSwitchId, bool value)
        {
            EventSwitchId = eventSwitchId;
            Value = value; 
        }
        public void Initialize()
        {
            Done = false; 
        }

        public void Update(double gameTime)
        {
            ManagerLists.SetEventSwitchValue(EventSwitchId, Value);
            Done = true; 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}


