using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Gui;

namespace Zelda.Components
{
    public class GUI : Component
    {
        private readonly PlayerStatsGui _playerStatsGui;

        public GUI()
        {
            _playerStatsGui = new PlayerStatsGui();
        }

        public void LoadContent(ContentManager content)
        {
            _playerStatsGui.LoadContent(content);
        }

        public override void Update(double gameTime)
        {
           _playerStatsGui.Update(GetComponent<Stats>(), GetComponent<Equipment>());
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            _playerStatsGui.Draw(spritebatch);
        }
    }
}