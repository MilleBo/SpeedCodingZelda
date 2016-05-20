//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP.Manager
{
    public static class ManagerContent
    {
        private static Dictionary<string, Texture2D> _textureList;
        private static Dictionary<string, SpriteFont> _fontList;  
        private static ContentManager _content;

        public static void Initialize(ContentManager content)
        {
            _textureList = new Dictionary<string, Texture2D>();
            _fontList = new Dictionary<string, SpriteFont>();
            _content = content; 
        }

        public static Texture2D LoadTexture(string textureName)
        {
            if (!_textureList.ContainsKey(textureName))
            {
                _textureList.Add(textureName, _content.Load<Texture2D>("Textures/" + textureName));
            }
            return _textureList[textureName]; 
        }

        public static SpriteFont LoadFont(string fontName)
        {
            if (!_fontList.ContainsKey(fontName))
            {
                _fontList.Add(fontName, _content.Load<SpriteFont>("Fonts/" + fontName));
            }
            return _fontList[fontName];
        }



    }



}



