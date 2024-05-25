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
                    room.Enemy = new Enemy(5,2);
                }
            }
        }

        public Room GetStartingRoom()
        {
            return rooms[0];
        }

        public Room GetRoomById(int id)
        {
            foreach (Room room in rooms)
            {
                if(room.Id == id){
                    return room;
                }
            }
            return null;
        }
    }
    
}