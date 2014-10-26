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
using LetsCreateZelda.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Manager
{
    public class ManagerScreen
    {
        private Screen _lastScreen; 
        private Screen _currentScreen;
        private ContentManager _content;
        private Texture2D _backgroundTexture;
        private double _counter;
        private byte _alpha;
        private Screen _tempScreenHolder;
        private bool _loadContent; 

        private enum Phase
        {
            FadeOut,
            FadeIn,
            Running
        };

        private Phase _currentPhase; 

        public ManagerScreen(ContentManager content)
        {
            _content = content;
            _backgroundTexture = ManagerContent.LoadTexture("white_background");
                //content.Load<Texture2D>("Textures/white_background"); 
        }

        public void LoadNewScreen(Screen screen, bool fade = true, bool loadContent = true)
        {
            ManagerInput.PauseInput(750);
            _tempScreenHolder = screen;
            _loadContent = loadContent; 
            if (!fade)
            {
                AfterFadeOut();
                _currentPhase = Phase.Running;
                return; 
            }          
            _currentPhase = Phase.FadeOut;
            _counter = 0;
            _alpha = 0;
        }

        public void GoBackOneScreen()
        {
            if (_lastScreen == null)
                return;
            LoadNewScreen(_lastScreen, true, false);
        }

        public void Update(double gameTime)
        {
            switch (_currentPhase)
            {
                case Phase.FadeOut:
                    FadeOut(gameTime);
                    break;
                case Phase.FadeIn:
                    FadeIn(gameTime);
                    break;
                case Phase.Running:
                    _currentScreen.Update(gameTime);
                    break;
            }
        }

        private void FadeIn(double gameTime)
        {
            _counter += gameTime;
            if (_counter > 100)
            {
                _alpha -= 15;
            }
            if (_alpha == 0)
            {
                _currentPhase = Phase.Running;
            }
        }

        private void FadeOut(double gameTime)
        {
            _counter += gameTime;
            if (_counter > 100)
            {
                _alpha += 15;
            }

            if (_alpha == 255)
            {
                AfterFadeOut();
                _currentPhase = Phase.FadeIn;
                _counter = 0;
            }
        }

        private void AfterFadeOut()
        {
            _lastScreen = _currentScreen;
            if (_lastScreen != null)
                _lastScreen.Uninitialize();
            _currentScreen = _tempScreenHolder;
            if(_loadContent)
                _currentScreen.LoadContent(_content);
            _currentScreen.Initialize();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_currentScreen != null)
            {
                _currentScreen.Draw(spriteBatch);
            }

            if (_currentPhase == Phase.FadeIn || _currentPhase == Phase.FadeOut)
            {
                spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, 160, 144), new Color(0, 0, 0, _alpha));
            }
        }

    }
}




