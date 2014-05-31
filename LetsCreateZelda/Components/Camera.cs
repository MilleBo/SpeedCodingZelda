using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components
{
    class Camera : Component
    {
        private ManagerCamera _managerCamera; 

        public override ComponentType ComponentType
        {
            get { return ComponentType.Camera; }
        }

        public Camera(ManagerCamera camera)
        {
            _managerCamera = camera; 
        }

        public bool GetPosition(Vector2 position, out Vector2 newPosition)
        {
            newPosition = _managerCamera.WorldToScreenPosition(position);
            return _managerCamera.InScreenCheck(position); 
        }

        public bool InsideScreen(Vector2 position)
        {
            return _managerCamera.InScreenCheck(position);
        }

        public void MoveCamera(Direction direction)
        {
            _managerCamera.Move(direction);
        }

        public bool CameraInTransition()
        {
            return _managerCamera.Locked;
        }

        public override void Update(double gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            
        }
    }
}
