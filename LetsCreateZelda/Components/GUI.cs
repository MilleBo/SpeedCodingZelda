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
using LetsCreateZelda.Gui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components
{
    class GUI : Component
    {
        private PlayerStatsGui _playerStatsGui; 

        public override ComponentType ComponentType
        {
            get { return ComponentType.GUI;  }
        }

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
           _playerStatsGui.Update(GetComponent<Stats>(ComponentType.Stats),GetComponent<Equipment>(ComponentType.Equipment));
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            _playerStatsGui.Draw(spritebatch);
        }
    }
}





