using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components.Enemies
{
    class Octorok : Component
    {

        private BaseObject _player;
        private List<OctorokBullet> _bullets;
        private double _counter; 
        private int _cooldown;
        private Texture2D _bulletTexture;
        private ManagerMap _map; 

        public Octorok(BaseObject player, Texture2D bulletTexture, ManagerMap map, int cooldown = 2000)
        {
            _player = player; 
            _bullets = new List<OctorokBullet>();
            _cooldown = cooldown;
            _counter = 0;
            _bulletTexture = bulletTexture;
            _map = map; 
        }


        public override ComponentType ComponentType
        {
            get { return ComponentType.EnemyOctorok; }
        }

        public override void Update(double gameTime)
        {
            _counter += gameTime;

            var i = 0; 
            while(i < _bullets.Count)
            {
               _bullets[i].Update(gameTime);
               if (_bullets[i].Dead)
                   _bullets.RemoveAt(i);
               else
                   i++; 
            }

            if (_counter < _cooldown)
                return; 
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            var playerSprite = _player.GetComponent<Sprite>(ComponentType.Sprite);
            var animation = GetComponent<Animation>(ComponentType.Animation);
            if (sprite == null || animation == null || playerSprite == null)
                return;
            switch (animation.CurrentDirection)
            {
                    case Direction.Up:
                    if(playerSprite.Position.Y < sprite.Position.Y)
                        NewBullet(Direction.Up);
                    break;
                    case Direction.Down:
                    if (playerSprite.Position.Y > sprite.Position.Y)
                        NewBullet(Direction.Down);
                    break;
                    case Direction.Left:
                    if (playerSprite.Position.X < sprite.Position.X)
                        NewBullet(Direction.Left);
                    break;
                    case Direction.Right:
                    if (playerSprite.Position.X > sprite.Position.X)
                        NewBullet(Direction.Right);
                    break; 
            }

            
        }

        private void NewBullet(Direction direction)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            _bullets.Add(new OctorokBullet(new Sprite(_bulletTexture,10,10,sprite.Position),new Collision(_map), _player,direction));
             _counter = 0;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            foreach (var octorokBullet in _bullets)
            {
                octorokBullet.Draw(spritebatch); 
            }
        }
    }
}
