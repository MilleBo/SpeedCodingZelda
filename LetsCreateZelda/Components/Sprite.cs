using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components
{
    class Sprite : Component
    {
        private Texture2D _texture;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Vector2 Position { get; private set; }

        public Color Color { get; set; }

        public Sprite(Texture2D texture, int width, int height, Vector2 position)
        {
            _texture = texture;
            Width = width;
            Height = height;
            Position = position;
            Color = Color.White; 
        }

        public override ComponentType ComponentType
        {
            get { return ComponentType.Sprite; }
        }

        public Rectangle Rectangle { get {return new Rectangle((int) Position.X, (int) Position.Y, Width,Height);}}

        public override void Update(double gameTime)
        {
           
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            var camera = GetComponent<Camera>(ComponentType.Camera);
            Vector2 position;
            if (!(camera != null && camera.GetPosition(Position, out position)))
                return; 
                

            var animation = GetComponent<Animation>(ComponentType.Animation);
            if (animation != null)
            {
                spritebatch.Draw(_texture, new Rectangle((int)position.X, (int)position.Y, Width, Height),animation.TextureRectangle,Color);
            }
            else
            {
                spritebatch.Draw(_texture, new Rectangle((int) position.X, (int) position.Y, Width, Height),
                                 Color);
            }
        }

        public void Move(float x, float y)
        {
            Position = new Vector2(Position.X + x, Position.Y + y);

            var animation = GetComponent<Animation>(ComponentType.Animation);
            if (animation == null)
                return; 

            if(x > 0)
            {
                animation.PlayAnimation(State.Walking, Direction.Right);
            }
            else if(x < 0)
            {
                animation.PlayAnimation(State.Walking, Direction.Left);
            }
            else if(y > 0)
            {
                animation.PlayAnimation(State.Walking, Direction.Down);
            }
            else if(y < 0)
            {
                animation.PlayAnimation(State.Walking, Direction.Up);  
            }
        }

        public void Teleport(Vector2 position)
        {
            Position = new Vector2(position.X,position.Y);
        }

        public void Move(Direction direction, int speed)
        {
            switch (direction)
            {
                    case Direction.Up:
                    Move(0,speed*-1);
                    break; 

                    case Direction.Down:
                    Move(0, speed);
                    break; 

                    case Direction.Left:
                    Move(speed*-1, 0);
                    break; 

                    case Direction.Right:
                    Move(speed, 0);
                    break; 
            }

        }
    }
}
