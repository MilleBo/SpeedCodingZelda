﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateZelda.Components;
using LetsCreateZelda.Components.Enemies;
using LetsCreateZelda.Components.Items;
using LetsCreateZelda.Components.Movement;
using LetsCreateZelda.Factories;
using LetsCreateZelda.Gui;
using LetsCreateZelda.Manager;
using LetsCreateZelda.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Screens
{
    class ScreenWorld : Screen
    {
        private ManagerMap _managerMap;
        private ManagerCamera _managerCamera;
        private Entities _entities;
        private ManagerEvents _managerEvents; 

        public ScreenWorld(ManagerScreen managerScreen) : base(managerScreen)
        {
            _managerCamera = new ManagerCamera();
            _managerMap = new ManagerMap("newmap", _managerCamera);
            _entities = new Entities();
            _managerEvents = new ManagerEvents();
            //uglyyyyyyy
            FactoryDeathAnimation.Initailize(_managerCamera);
        }

        public override void Initialize()
        {
           
        }

        public override void LoadContent(ContentManager content)
        {
            _managerMap.LoadContent();

            var player = new BaseObject {Id = "player"}; 
            player.AddComponent(new Sprite(content.Load<Texture2D>("link_full"), 16, 16, new Vector2(50, 50)));
            player.AddComponent(new PlayerInput());
            player.AddComponent(new Animation(16, 16,2));
            player.AddComponent(new Collision(_managerMap));
            player.AddComponent(new Camera(_managerCamera));
            player.AddComponent(new Equipment(content,_managerMap,_managerCamera));
            player.GetComponent<Equipment>(ComponentType.Items).AddItem(new Boomerang());
            player.GetComponent<Equipment>(ComponentType.Items).AddItem(new Sword(_entities));
            player.GetComponent<Equipment>(ComponentType.Items).EquipItemInSlot(1,ItemSlot.A);
            player.GetComponent<Equipment>(ComponentType.Items).EquipItemInSlot(2, ItemSlot.B);
            player.AddComponent(new Damage(_entities,true));
            player.AddComponent(FactoryStats.GetStats("Link"));

            player.AddComponent(new GUI());
            player.GetComponent<GUI>(ComponentType.GUI).LoadContent(content);
            

            //var testNPC = new BaseObject();
            //testNPC.AddComponent(new Sprite(content.Load<Texture2D>("Marin"), 16, 16, new Vector2(50, 50)));
            //testNPC.AddComponent(new AIMovementRandom(200));
            //testNPC.AddComponent(new Animation(16, 16));
            //testNPC.AddComponent(new Collision(_managerMap));
            //testNPC.AddComponent(new Camera(_managerCamera));
            _entities.AddEntity(player);
            for (int n = 0; n < 3; n++)
            {
                var testEnemy = new BaseObject {Id = string.Format("enemy_{0}", n)};
                testEnemy.AddComponent(new Sprite(content.Load<Texture2D>("Octorok"), 16, 16, new Vector2(50 + ManagerFunction.Random(10,20), 50 + ManagerFunction.Random(10,20))));
                testEnemy.AddComponent(new AIMovementRandom(1000, 0.5f));
                testEnemy.AddComponent(new Animation(16, 16, 2));
                testEnemy.AddComponent(new Collision(_managerMap));
                testEnemy.AddComponent(new Octorok(player, content.Load<Texture2D>("Octorok_bullet"), _managerMap));
                testEnemy.AddComponent(new Camera(_managerCamera));
                testEnemy.AddComponent(new Damage(_entities));
                testEnemy.AddComponent(FactoryStats.GetStats("Octorok"));
                _entities.AddEntity(testEnemy);
            }


            
            //_entities.AddEntity(testNPC);
            

        

            //Just for test
            //var window = new WindowMessage("Hello, this is a message! This is a long message",content);
            //ManagerWindow.NewWindow("test_message",window);
        }

        public override void Update(double gameTime)
        {
            _entities.Update(gameTime);
            _managerMap.Update(gameTime);
            _managerCamera.Update(gameTime);
            _managerEvents.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _managerMap.Draw(spriteBatch);
            _entities.Draw(spriteBatch);
            _managerEvents.Draw(spriteBatch);
        }
    }
}