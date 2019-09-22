//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Manager;

namespace Zelda.Components
{
    class Camera : Component
    {
        private ManagerCamera _managerCamera;

        public Vector2 CameraPosition => _managerCamera.Position;

        public Vector2 CameraTilePositon => _managerCamera.TilePosition;

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



