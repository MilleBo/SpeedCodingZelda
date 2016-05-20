//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using LetsCreateZelda.UWP.GameEvent;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP.Manager
{
    class ManagerEvents
    {
        private static List<IGameEvent> _eventList;
        private static int _index; 

        public static bool Active
        {
            get; private set; 
        }

        public ManagerEvents()
        {
            _eventList = new List<IGameEvent>();
        }

        public static void AddEvents(List<IGameEvent> events)
        {
            if(_eventList == null)
                _eventList = new List<IGameEvent>();

            if (!_eventList.Any())
            {
                _eventList.AddRange(events);
                ResetEvents();
                Active = true;
            }
            else
            {
                _eventList.AddRange(events);
            }
        }

        private static void ResetEvents()
        {
            _index = 0; 
            if(_eventList.Any())
                _eventList[0].Initialize();
        }

        public void Update(double gameTime)
        {
            if (!_eventList.Any())
            {
                Active = false;
                return; 
            }

            if (!_eventList[_index].Done)
                _eventList[_index].Update(gameTime);
            else
            {
                _index++;
                if (_index > _eventList.Count - 1)
                {
                    Active = false;
                    _eventList.Clear();
                }
                else
                {
                    _eventList[_index].Initialize();
                }
            }       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_eventList.Any())
                 _eventList[_index].Draw(spriteBatch);
        }
        

    }
}




