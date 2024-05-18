using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Player : Character
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="health"> The Health of the player </param>
        /// <param name="attackPower"> The Damage the player does </param>
        public Player(int health, int attackPower) : base(health, attackPower)
        {
            
        }

        //Do we need to store its position?
        public void Move(){}

        //Does this mean we need an inventory?
        public void PickUpItem(){}

        //Probably uses a Heal item
        public void Heal(){}

    }
}