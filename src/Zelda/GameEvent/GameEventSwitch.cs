using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;

namespace Zelda.GameEvent
{
    public class GameEventSwitch : IGameEvent
    {
        public GameEventSwitch(int eventSwitchId, bool value)
        {
            EventSwitchId = eventSwitchId;
            Value = value;
        }

        public bool Done { get; set; }

        public int EventSwitchId { get; set; }

        public bool Value { get; set; }

        public GameEventType EventType => GameEventType.EventSwitch;

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