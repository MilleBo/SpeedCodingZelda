using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameEvent;
using Zelda.Manager;

namespace Zelda.Components.EventTriggers
{
    public class EventTriggerDistance : Component
    {
        private readonly List<IGameEvent> _gameEvent;
        private readonly List<BaseObject> _targetList;
        private readonly int _distance;
        private readonly double _cooldown;
        private double _counter;

        public EventTriggerDistance(List<IGameEvent> gameEvents, List<BaseObject> targetList, int distance, double cooldown = 0)
        {
            _gameEvent = gameEvents;
            _targetList = targetList;
            _distance = distance;
            _cooldown = cooldown;
            _counter = 0;
        }

        public override void Update(double gameTime)
        {
            if (ManagerEvents.Active)
            {
                return;
            }

            _counter += gameTime;
            if (_counter < _cooldown)
            {
                return;
            }

            var ownerSprite = GetComponent<Sprite>();
            if (ownerSprite == null)
            {
                return;
            }

            foreach (var baseObject in _targetList)
            {
                var sprite = baseObject.GetComponent<Sprite>();
                if (sprite != null)
                {
                    if (ManagerFunction.Distance(ownerSprite.Position, sprite.Position) < _distance)
                    {
                        ManagerEvents.AddEvents(_gameEvent);
                        _counter = 0;
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
        }
    }
}
