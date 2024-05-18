using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Room
    {
        Enemy enemy;
        Item item;
        int id;
        int [] connectedRoomIds = new int [4];
        Room[] ConnectedRooms = new Room[4];
        bool isExit;
        string description;

        public Room(int id, bool hasEnemy,Item item,int[] connectedRoomIds, bool isExit)
        {
            this.id = id;
            enemy = hasEnemy ? new Enemy(5,1) : null;
            this.item = item;
            this.connectedRoomIds = connectedRoomIds;
            this.isExit = isExit;
        }

        public override string ToString()
        {
            return $"Room {id}: Connections: {string.Join(", ", connectedRoomIds)} Is Exit: {isExit}";
        }
    }
}