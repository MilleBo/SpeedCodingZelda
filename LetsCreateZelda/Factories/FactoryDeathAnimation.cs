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
using LetsCreateZelda.Components;
using LetsCreateZelda.Components.DeathAnimations;
using LetsCreateZelda.Components.Items;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Factories
{
    class FactoryDeathAnimation
    {
        private static ManagerCamera _camera; 

        public static void Initailize(ManagerCamera camera)
        {
            _camera = camera; 
        }

        public static BaseObject GetDeathAnimationObject(DeathAnimation deathAnimation, Vector2 position)
        {
            var baseObject = new BaseObject {Id = "deathAnimation"};
            switch (deathAnimation)
            {
                    case DeathAnimation.Explosion:
                    baseObject.AddComponent(new Sprite(ManagerContent.LoadTexture("death_effect"), 16, 16, position));
                    baseObject.AddComponent(new Animation(16, 16, 3,100));
                    baseObject.AddComponent(new DeathAnimationExplosion());
                    baseObject.AddComponent(new Camera(_camera));
                    break; 
            }

            return baseObject;
        }
    }
}




