using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Components;
using LetsCreateZelda.GameEvent;
using LetsCreateZelda.Manager;

namespace LetsCreateZelda.Map
{
    class TileEvent : TileCollision
    {
        private readonly Dictionary<int, List<IGameEvent>> _gameEvents;


        public TileEvent(int xPos, int yPos, Dictionary<int, List<IGameEvent>> gameEvents)
        {
            XPos = xPos;
            YPos = yPos;
            _gameEvents = gameEvents; 
        }

        public void StartEvent()
        {
            if (!ManagerEvents.Active)
            {
                var keys = _gameEvents.Keys;
                var biggest = -1;
                foreach (int key in keys)
                {
                    if (key > biggest && ManagerLists.GetEventSwitchValue(key))
                        biggest = key; 
                }

                if(biggest != -1)
                    ManagerEvents.AddEvents(_gameEvents[biggest]); 
            }
                
        }
    }
}
