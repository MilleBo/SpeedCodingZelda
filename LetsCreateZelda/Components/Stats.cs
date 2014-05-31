using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateZelda.Components
{
    public class Stats : Component, ICloneable
    {
        public string StatsId { get; set; }
        public int Health { get; set; }

        [NonSerialized] private int _currentHealth; 
        public int CurrentHealth { get { return _currentHealth; }}
        public int Attack { get; set; }
        public int Defense { get; set; }

        public Stats(string statsId, int health, int attack, int defense)
        {
            StatsId = statsId;
            Health = health;
            _currentHealth = Health;
            Attack = attack;
            Defense = defense; 
        }

        public Stats() { }

        public override ComponentType ComponentType
        {
            get { return ComponentType.Stats; }
        }

        public override void Update(double gameTime)
        {
           
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            
        }

        public Object Clone()
        {
            return new Stats
                   {
                       _currentHealth = Health,
                       Attack = Attack,
                       Defense = Defense,
                       Health = Health,
                       StatsId = StatsId
                   };
        }

        public void ReduceHealth(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                KillBaseObject();
            }
        }
    }
}
