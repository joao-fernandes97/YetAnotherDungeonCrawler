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
        public int Id {get; set;}
        public string Description {get; set;}
        public Dictionary<string, int> Exits {get; set;}
        public bool IsExit {get; set;}
        public bool HasEnemy {get; set;}
        public bool HasItem {get; set;}
        

        public Room(){}

        public override string ToString()
        {
            return $"";
        }
    }
}