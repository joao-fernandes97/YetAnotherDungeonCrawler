using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Dungeon
    {
        readonly List<Room> rooms;

        public Dungeon(List<Room> rooms)
        {
            this.rooms = rooms;
        }

        public void PopulateRooms()
        {
            foreach (Room room in rooms)
            {
                if(room.HasEnemy)
                {
                    room.Enemy = new Enemy(1,1);
                }

                if(room.HasItem)
                {
                    room.Item = Item.HealthPotion;
                }
            }
        }

        public Room GetStartingRoom()
        {
            return rooms[0];
        }
    }
    
}