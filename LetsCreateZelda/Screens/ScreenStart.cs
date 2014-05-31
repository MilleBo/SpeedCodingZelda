using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Screens
{
    class ScreenStart : Screen
    {

        private Texture2D _image; 

        public ScreenStart(ManagerScreen managerScreen) : base(managerScreen)
        {
            
        }

        public override void LoadContent(ContentManager content)
        {
            _image = content.Load<Texture2D>("start_screen");
        }

        public override void Initialize()
        {
            ManagerInput.FireNewInput += ManagerInput_FireNewInput;
        }

        public override void Uninitialize()
        {
            ManagerInput.FireNewInput -= ManagerInput_FireNewInput;
        }

        void ManagerInput_FireNewInput(object sender, MyEventArgs.NewInputEventArgs e)
        {
            if(e.Input == Input.Enter)
            {
                ManagerScreen.LoadNewScreen(new ScreenWorld(ManagerScreen));
            }
        }


        public override void Update(double gameTime)
        {
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image,new Rectangle(0,0,160,144),Color.White);
        }
    }
}
