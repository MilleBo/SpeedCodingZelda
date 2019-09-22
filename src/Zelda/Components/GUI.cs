//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Gui;

namespace Zelda.Components
{
    class GUI : Component
    {
        private PlayerStatsGui _playerStatsGui;

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
           _playerStatsGui.Update(GetComponent<Stats>(),GetComponent<Equipment>());
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            _playerStatsGui.Draw(spritebatch);
        }
    }
}





