using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Player : Character
    {
        private int maxHealth;
        public Room room;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="health"> The Health of the player </param>
        /// <param name="attackPower"> The Damage the player does </param>
        public Player(int health, int attackPower) : base(health, attackPower)
        {
            maxHealth = health;
        }

        //Do we need to store its position?
        public int Move(string direction)
        {
            return room.Exits[direction];
        }

        //Does this mean we need an inventory?
        public void PickUpItem(){}

        //Probably uses a Heal item
        public void Heal()
        {
            //Needs to check for heal in inventory.
            Health += 10;

            // Caps the health of the player at the established maximum.
            if (Health > maxHealth)
            {
                Health = maxHealth;
            }
        }

    }
}