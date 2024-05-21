using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class View
    {
        private Player player;
        public View(Player player)
        {
            this.player = player;
        }
        
        public string ReadOption()
        {
            return Console.ReadLine();
        }
        public void WelcomeMsg()
        {
            Console.WriteLine("Welcome!");
        }

        public void InvalidOption()
        {
            Console.WriteLine("Invalid Option");
        }

        public void PrintRoomDescription(Room room)
        {
            Console.WriteLine(room.Description);
        }

        public void ReadDungeonMap()
        {

        }

        public List<Room> ReadRoomConfig()
        {
            //string directory = Directory.GetCurrentDirectory();
            string filename = "Rooms.JSON";
            //string fullPath = Path.Combine(directory, filename);

            if(File.Exists(filename))
            {
                //using StreamReader sr = new StreamReader(fullPath);
                string text = File.ReadAllText(filename);
                List<Room> roomList = JsonConvert.DeserializeObject<List<Room>>(text);

                return roomList;
            }
            
            
            Console.WriteLine($"File '{filename}' not found in current directory.");
            return new List<Room>();
        }

        public void PrintRoomList(List<Room> roomList)
        {
            foreach (Room room in roomList)
            {
                Console.WriteLine(room.ToString());
            }

        }

        public void HealthRestoredMsg()
        {
            int hp = player.Health;
            Console.WriteLine($"The player is at {hp} health.");
        }

        public void NoHealsMsg()
        {
            Console.WriteLine("The player was unable to heal.");
        }

        public void NoPathFoundMsg()
        {
            Console.WriteLine("Couldn't find a path in that direction!");
        }
        
        public void EnemyMsg()
        {
            Console.WriteLine("There's an enemy in this room.");
        }

        public void ItemMsg()
        {
            Console.WriteLine("There's an item in this room.");
        }

        public void NoEnemyMsg()
        {
            Console.WriteLine("There isn't any enemy in this room.");
        }

        public void NoItemMsg()
        {
            Console.WriteLine("There isn't any item in this room.");
        }
    }
}