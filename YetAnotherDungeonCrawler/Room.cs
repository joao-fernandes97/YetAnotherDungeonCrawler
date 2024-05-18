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
        Room[] ConnectedRooms = new Room[4];
        bool isExit;
        string description;
    }
}