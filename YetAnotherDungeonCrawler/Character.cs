using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Character
    {
        public int Health { get; private set; }
        public int AttackPower { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="health"> The Health of the character </param>
        /// <param name="attackPower"> The Damage the character does </param>
        public Character(int health, int attackPower)
        {
            Health = health;
            AttackPower = attackPower;
        }

        /// <summary>
        /// Attack another character
        /// </summary>
        /// <param name="other"> target of the attack </param>
        public void Attack(Character other)
        {
            // Subtract AP to other the target's health
            other.Health -= AttackPower;

            // If the target's health is bellow 0 it goes to 0
            if (other.Health < 0)
            {
                other.Health = 0;
            }
        }
    }
}