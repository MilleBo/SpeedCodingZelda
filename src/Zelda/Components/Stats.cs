using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Components
{
    public class Stats : Component
    {
        public Stats(string statsId, int health, int attack, int defense, int speed)
        {
            StatsId = statsId;
            Health = health;
            CurrentHealth = Health;
            Attack = attack;
            Defense = defense;
            Speed = speed;
        }

        public Stats()
        {
        }

        public string StatsId { get; set; }

        public int Health { get; set; }

        public int CurrentHealth { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public float Speed { get; set; }

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
                       CurrentHealth = Health,
                       Attack = Attack,
                       Defense = Defense,
                       Health = Health,
                       StatsId = StatsId,
                       Speed = Speed
                   };
        }

        public void ReduceHealth(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                KillBaseObject();
            }
        }
    }
}