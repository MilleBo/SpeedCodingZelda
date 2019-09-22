using Microsoft.Xna.Framework;
using Zelda.Components;
using Zelda.Components.DeathAnimations;
using Zelda.Manager;

namespace Zelda.Factories
{
    public class FactoryDeathAnimation
    {
        private static ManagerCamera _camera;

        public static void Initailize(ManagerCamera camera)
        {
            _camera = camera;
        }

        public static BaseObject GetDeathAnimationObject(DeathAnimation deathAnimation, Vector2 position)
        {
            var baseObject = new BaseObject { Id = "deathAnimation" };
            switch (deathAnimation)
            {
                    case DeathAnimation.Explosion:
                    baseObject.AddComponent(new Sprite(ManagerContent.LoadTexture("death_effect"), 16, 16, position));
                    baseObject.AddComponent(new Animation(16, 16, 3, 100));
                    baseObject.AddComponent(new DeathAnimationExplosion());
                    baseObject.AddComponent(new Camera(_camera));
                    break;
            }

            return baseObject;
        }
    }
}
