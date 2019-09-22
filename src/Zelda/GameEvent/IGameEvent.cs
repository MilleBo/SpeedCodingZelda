using Microsoft.Xna.Framework.Graphics;

namespace Zelda.GameEvent
{
    public interface IGameEvent
    {
        bool Done { get; set; }

        GameEventType EventType { get; }

        void Initialize();

        void Update(double gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}