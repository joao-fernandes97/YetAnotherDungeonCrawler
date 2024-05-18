using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Player
    {
        public int Health { get; private set; }
        public int AttackPower { get; private set; }

        //Construtor
        public Player()
        {

        }

        //Do we need to store its position?
        public void Move(){}

        //Probably needs a target to attack
        public void Attack(){}

        //Does this mean we need an inventory?
        public void PickUpItem(){}

        //Probably uses a Heal item
        public void Heal(){}

    }
}