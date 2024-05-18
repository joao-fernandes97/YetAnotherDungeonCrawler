using System;
using System.Collections.Generic;


namespace YetAnotherDungeonCrawler
{
    public class Enemy : Character
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="health"> The Health of the enemy </param>
        /// <param name="attackPower"> The Damage the enemy does </param>
        public Enemy(int health, int attackPower) : base(health, attackPower)
        {

        }
    }
}