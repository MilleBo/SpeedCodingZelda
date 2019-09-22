using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;
using Zelda.Map;

namespace Zelda.Components.Enemies
{
    public class Octorok : Component
    {
        private readonly BaseObject _player;
        private readonly List<OctorokBullet> _bullets;
        private readonly int _cooldown;
        private readonly Texture2D _bulletTexture;
        private readonly ManagerMap _map;
        private readonly Entities _entities;
        private double _counter;

        public Octorok(BaseObject player, Texture2D bulletTexture, ManagerMap map,  Entities entities, int cooldown = 2000)
        {
            _player = player;
            _bullets = new List<OctorokBullet>();
            _cooldown = cooldown;
            _counter = 0;
            _bulletTexture = bulletTexture;
            _map = map;
            _entities = entities;
        }

        public override void Update(double gameTime)
        {
            _counter += gameTime;

            var i = 0;

            while (i < _bullets.Count)
            {
               _bullets[i].Update(gameTime);
               if (_bullets[i].Dead)
               {
                   _bullets.RemoveAt(i);
                   continue;
               }

               i++;
            }

            if (_counter < _cooldown)
            {
                return;
            }

            var sprite = GetComponent<Sprite>();
            var playerSprite = _player.GetComponent<Sprite>();
            var animation = GetComponent<Animation>();
            if (sprite == null || animation == null || playerSprite == null)
            {
                return;
            }

            switch (animation.CurrentDirection)
            {
                    case Direction.Up:
                        if (playerSprite.Position.Y < sprite.Position.Y)
                        {
                            NewBullet(Direction.Up);
                        }

                        break;

                    case Direction.Down:
                        if (playerSprite.Position.Y > sprite.Position.Y)
                        {
                            NewBullet(Direction.Down);
                        }

                        break;
                    case Direction.Left:
                        if (playerSprite.Position.X < sprite.Position.X)
                        {
                            NewBullet(Direction.Left);
                        }

                        break;

                    case Direction.Right:
                        if (playerSprite.Position.X > sprite.Position.X)
                        {
                            NewBullet(Direction.Right);
                        }

                        break;
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            foreach (var octorokBullet in _bullets)
            {
                octorokBullet.Draw(spritebatch);
            }
        }

        private void NewBullet(Direction direction)
        {
            var sprite = GetComponent<Sprite>();
            _bullets.Add(new OctorokBullet(new Sprite(_bulletTexture, 10, 10, sprite.Position), new Collision(_map, _entities), _player, direction));
            _counter = 0;
        }
    }
}