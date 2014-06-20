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
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.GameEvent
{
    class GameEventSwitch : IGameEvent
    {
        public bool Done { get; set; }
        public int EventSwitchId { get; set; }
        public bool Value { get; set; }
        public GameEventType EventType { get { return GameEventType.EventSwitch;  }}

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


