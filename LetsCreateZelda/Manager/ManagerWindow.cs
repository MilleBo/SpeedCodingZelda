using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Gui;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Manager
{
    public class ManagerWindow
    {
        private static readonly Dictionary<string, Window> WindowList = new Dictionary<string, Window>();


        public static void NewWindow(string id, Window window)
        {
            if(!WindowList.ContainsKey(id))
            {
                WindowList.Add(id,window);
                window.Reset();
            }
        }

        public static void RemoveAll()
        {
            foreach (var window in WindowList)
            {
                window.Value.Active = false;
                window.Value.Done = true; 
                window.Value.DeInitialize();
            }

            WindowList.Clear();
        }

        public static Window GetWindow(string id)
        {
            return WindowList.ContainsKey(id) ? WindowList[id] : null; 
        }

        public static bool Contains(string id)
        {
            return WindowList.ContainsKey(id); 
        }

        public void Update(double gameTime)
        {
            var i = 0;
            while (i < WindowList.Count)
            {
                if(WindowList.ElementAt(i).Value.Active && !WindowList.ElementAt(i).Value.Done)
                    WindowList.ElementAt(i).Value.Update(gameTime);

                if (WindowList.Count > i && !WindowList.ElementAt(i).Value.AMenu && WindowList.ElementAt(i).Value.Done)
                {
                    WindowList.ElementAt(i).Value.DeInitialize();
                    WindowList.Remove(WindowList.ElementAt(i).Key);
                }
                else
                    i++; 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(WindowList.Count > 0)
            {
                var list = WindowList.ToList();
                foreach (var window in list)
                {
                    window.Value.Draw(spriteBatch);
                }
            }
        }


    }
}
