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
using LetsCreateZelda.GameEvent;
using LetsCreateZelda.Manager;
using LetsCreateZelda.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OpenTK.Graphics.OpenGL;

namespace LetsCreateZelda.Components
{
    class PlayerInput : Component
    {

        private ManagerScreen _managerScreen;
        private ManagerPlayer _managerPlayer;

        public override ComponentType ComponentType
        {
            get { return ComponentType.PlayerInput; }
        }



        public PlayerInput(ManagerScreen managerScreen, ManagerPlayer managerPlayer)
        {
            _managerScreen = managerScreen;
            _managerPlayer = managerPlayer;
        }

        void ManagerInput_FireNewInput(object sender, MyEventArgs.NewInputEventArgs e)
        {
            var sprite = GetComponent<Sprite>(ComponentType.Sprite);
            if (sprite == null)
                return;

            var collision = GetComponent<Collision>(ComponentType.Collision); 

            var x = 0f;
            var y = 0f;

            var camera = GetComponent<Camera>(ComponentType.Camera);
            if (camera == null)
                return;
            var animation = GetComponent<Animation>(ComponentType.Animation);
            Equipment equipment; 
            if (!camera.CameraInTransition())
            {
                switch (e.Input)
                {
                    case Input.Up:
                        y = -1.5f;
                        break;

                    case Input.Down:
                        y = 1.5f;
                        break;

                    case Input.Left:
                        x = -1.5f;
                        break;

                    case Input.Right:
                        x = 1.5f;
                        break;
                    case Input.A:
                        if(animation.CurrentState == State.Walking)
                            animation.StopAnimation();
                        equipment = GetComponent<Equipment>(ComponentType.Equipment); 
                        equipment.FireItem(ItemSlot.A);
                        break;
                    case Input.S:
                        if (animation.CurrentState == State.Walking)
                            animation.StopAnimation();
                        //ManagerEvents.AddEvents(new List<IGameEvent> {new GameEventMessage("I just started a new event with my s button")});
                        equipment = GetComponent<Equipment>(ComponentType.Equipment); 
                        equipment.FireItem(ItemSlot.B);
                        break; 
                    case Input.Start: 
                        _managerScreen.LoadNewScreen(
                            new ScreenMainMenu(_managerScreen,
                                GetComponent<Stats>(ComponentType.Stats),
                                GetComponent<Equipment>(ComponentType.Equipment)));
                        break; 

                    case Input.Select:
                        camera = GetComponent<Camera>(ComponentType.Camera);
                        if(camera != null)
                            _managerScreen.LoadNewScreen(new ScreenOverworldMap(_managerScreen,_managerPlayer,
                                camera.CameraTilePositon));
                        break; 
                                                
                    default:
                        return;

                }             
            }

            if(collision == null || !collision.CheckCollisionWithTiles(new Rectangle((int) (sprite.Position.X + x), (int) (sprite.Position.Y + y),sprite.Width,sprite.Height)))
                sprite.Move(x, y);

            Vector2 position; 
            if(!camera.GetPosition(sprite.Position,out position))
            {               
                camera.MoveCamera(animation.CurrentDirection);
                UpdateMap(camera, animation.CurrentDirection);
            }
        }

        private void UpdateMap(Camera camera, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    _managerPlayer.UpdateMap((int)camera.CameraTilePositon.X - 1, (int)camera.CameraTilePositon.Y);
                    break;
                case Direction.Right:
                    _managerPlayer.UpdateMap((int)camera.CameraTilePositon.X + 1, (int)camera.CameraTilePositon.Y);
                    break;
                case Direction.Up:
                    _managerPlayer.UpdateMap((int)camera.CameraTilePositon.X, (int)camera.CameraTilePositon.Y - 1);
                    break;
                case Direction.Down:
                    _managerPlayer.UpdateMap((int)camera.CameraTilePositon.X, (int)camera.CameraTilePositon.Y + 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
        }

        public override void Initialize()
        {
            ManagerInput.FireNewInput -= ManagerInput_FireNewInput;
            ManagerInput.FireNewInput += ManagerInput_FireNewInput;
        }

        public override void Uninitalize()
        {
            ManagerInput.FireNewInput -= ManagerInput_FireNewInput;
        }


        public override void Update(double gameTime)
        {

        }

        public override void Draw(SpriteBatch spritebatch)
        {

        }
    }
}





