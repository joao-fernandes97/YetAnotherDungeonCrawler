using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public class Room
    {
        public Enemy Enemy { get; set; }
        public Item Item { get; set; }
        public int Id {get; set;}
        public string Description {get; set;}
        public Dictionary<string, int> Exits {get; set;}
        public bool IsExit {get; set;}
        public bool HasEnemy {get; set;}

        /// <summary>
        /// Empty Constructor used only to instantiate
        /// </summary>
        public Room(){}

        /// <summary>
        /// Override of the ToString method
        /// </summary>
        /// <returns> the id, exits and if it has an enemy and item </returns>
        public override string ToString()
        {
            string exits = "";
            foreach (KeyValuePair<string,int> kvp in Exits)
            {
                exits += string.Format("{0}:{1}",kvp.Key, kvp.Value);
            }
            return $"Room: {Id}, HasEnemy: {HasEnemy}, Exits:{exits}, Item: {Item}";
        }
    }
}