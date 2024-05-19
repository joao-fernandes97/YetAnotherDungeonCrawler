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
        public int Move(string direction)
        {
            int id;
            switch (direction)
            {
                case "North":
                id = 1;
                break;

                case "South":
                id = 2;
                break;

                case "East":
                id = 3;
                break;

                case "West":
                id = 4;
                break;
                
                default:
                id = 0;
                break;
            }
            return id;
        }

        //Does this mean we need an inventory?
        public void PickUpItem(){}

        //Probably uses a Heal item
        public void Heal(){}

    }
}