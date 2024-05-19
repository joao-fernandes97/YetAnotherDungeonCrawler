using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Player : Character
    {
        public Dictionary<Item, int> Inventory {get; private set;}
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

        /// <summary>
        /// Increments the amount of the item on the player's inventory
        /// </summary>
        /// <param name="item"> Item that the player picks up </param>
        public void PickUpItem(Item item)
        {
            if (item != Item.None)
            {
                Inventory[item]++;
            }
        }

        /// <summary>
        /// Heals the player
        /// </summary>
        public void Heal()
        {
            // Checks if there is a health potion in inventory
            if (Inventory[Item.HealthPotion] > 0)
            {
                // Decreases the amount of health potions in inventory
                Inventory[Item.HealthPotion]--;

                // Heals the player
                Health += 10;

                // Caps the health of the player at the established maximum.
                if (Health > maxHealth)
                {
                    Health = maxHealth;
                }
            }
        }

    }
}