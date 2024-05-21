using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Player : Character
    {
        public Dictionary<Item, int> Inventory {get; private set;}
        private int maxHealth;
        public Room Room { get; private set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="health"> The Health of the player </param>
        /// <param name="attackPower"> The Damage the player does </param>
        public Player(int health, int attackPower) : base(health, attackPower)
        {
            maxHealth = health;
        }

        public void SetStartingRoom(Room Room)
        {
            this.Room = Room;
        }
        
        public bool Move(string direction, Dungeon dungeon)
        {
            if(Room.Exits.ContainsKey(direction))
            {
                //if this method returns null I want to not assign the value
                //but that shouldn't happen unless the Rooms file is fucked
                Room = dungeon.GetRoomById(Room.Exits[direction]);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Increments the amount of the item on the player's inventory
        /// </summary>
        /// <param name="item"> Item that the player picks up </param>
        public void PickUpItem()
        {
            if (Room.Item != Item.None)
            {
                Inventory[Room.Item]++;
                Room.Item = Item.None;
                Room.HasItem = false;
            }
        }

        /// <summary>
        /// Heals the player
        /// </summary>
        public bool Heal()
        {
            // Returns bool to check if player healed or not.
            bool healBool = false;

            // Checks if there is a health potion in inventory
            // Also checks if health is below max health
            if (Inventory[Item.HealthPotion] > 0 && Health < maxHealth)
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
                healBool = true;
            }
            return healBool;

        }

        public bool HasValidTarget()
        {
            return Room.HasEnemy && Room.Enemy.Health > 0;
        }

    }
}