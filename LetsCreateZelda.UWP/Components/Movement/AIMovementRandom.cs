//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using LetsCreateZelda.UWP.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.UWP.Components.Movement
{
    class AIMovementRandom : Component
    {

        private Direction _currentDirection; 
        private readonly int _frequency; 
        private double _counter;
 
        public AIMovementRandom(int frequency)
        {
            _frequency = frequency; 
            ChangeDirection();        
        }


        public override void Update(double gameTime)
        {
            var sprite = GetComponent<Sprite>();
            if (sprite == null)
                return;
            var camera = GetComponent<Camera>();
            if (camera == null)
                return;
            if (!camera.InsideScreen(sprite.Position) || camera.CameraInTransition())
                return;
            var stats = GetComponent<Stats>();
            var speed = 1.5f; 
            if (stats != null)
            {
                speed = stats.Speed;
            }

            _counter += gameTime; 
            if(_counter > _frequency)
            {
                ChangeDirection();
            }

            var collision = GetComponent<Collision>(); 
            var x = 0f;
            var y = 0f;

            switch (_currentDirection)
            {
                case Direction.Up:
                    y = -1* speed;
                    break;

                case Direction.Down:
                    y = speed; 
                    break;

                case Direction.Left:
                    x = -1*speed; 
                    break;

                case Direction.Right:
                    x = speed;
                    break;
                default:
                    return;

            }

           if(collision.CheckCollisionWithTiles(new Rectangle((int)(sprite.Position.X + x), (int)(sprite.Position.Y + y), sprite.Width, sprite.Height)))
            {
                ChangeDirection();
                return; 
            }

           sprite.Move(x, y); 

        }

        private void ChangeDirection()
        {
            _counter = 0;
            _currentDirection = (Direction) ManagerFunction.Random(0, 3); 
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            
        }
    }
}




