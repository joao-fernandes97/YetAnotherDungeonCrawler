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
            Inventory = new Dictionary<Item, int>();
        }

        /// <summary>
        /// Sets the room for the player in the beginning of the game
        /// </summary>
        /// <param name="Room"> The room the player starts in </param>
        public void SetStartingRoom(Room Room)
        {
            this.Room = Room;
        }
        
        /// <summary>
        /// Changes the Room the player is in and returns true
        /// If the player does not change their room it returns false
        /// </summary>
        /// <param name="direction"> Corresponds to player's input </param>
        /// <param name="dungeon"> Used to know the room </param>
        /// <returns> Whether or not the player moved </returns>
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
            // Checks if there is an item to be picked up
            if (Room.Item != Item.None)
            {
                // If the item isn't in the inventory places one there
                if (!Inventory.ContainsKey(Room.Item))
                {
                    Inventory[Room.Item] = 1;
                }
                // If it's already in inventory increments it by one
                else
                {
                Inventory[Room.Item]++;
                }
                Room.Item = Item.None;
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
            if(Inventory.ContainsKey(Item.HealthPotion))
            {
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
            
            }
            return healBool;

        }

        /// <summary>
        /// Checks if there is an enemy in the room
        /// </summary>
        /// <returns> Whether or not the player has an enemy </returns>
        public bool HasValidTarget()
        {
            return Room.HasEnemy && Room.Enemy.Health > 0;
        }

    }
}