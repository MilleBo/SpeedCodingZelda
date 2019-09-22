//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - http://www.speedcoding.net
//------------------------------------------------------

using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Components
{
    public class Stats : Component
    {
        public string StatsId { get; set; }
        public int Health { get; set; }

        private int _currentHealth; 
        public int CurrentHealth => _currentHealth;
        public int Attack { get; set; }
        public int Defense { get; set; }

        public float Speed { get; set; }    

        public Stats(string statsId, int health, int attack, int defense, int speed)
        {
            StatsId = statsId;
            Health = health;
            _currentHealth = Health;
            Attack = attack;
            Defense = defense;
            Speed = speed; 
        }

        public Stats() { }

        public override void Update(double gameTime)
        {
           
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            
        }

        public object Clone()
        {
            return new Stats
                   {
                       _currentHealth = Health,
                       Attack = Attack,
                       Defense = Defense,
                       Health = Health,
                       StatsId = StatsId,
                       Speed = Speed
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




