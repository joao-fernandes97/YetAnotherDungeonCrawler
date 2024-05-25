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
            Console.WriteLine("Hear ye who enters this place, find the EXIT or GIVE UP and die.");
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
        
        /* public void TargetMsg(object t)
        {
            string target = t.GetType().Name;
            Console.WriteLine($"There's an {target} in this room.");
        } */

        public void EnemyMsg()
        {
            Console.WriteLine($"There's an enemy in this room. ATTACK to get rid of it.");
        }

        public void ItemMsg(Item item)
        {
            Console.WriteLine($"You can PICK UP the {item} to add it to your inventory");
        }

        public void NoTargetMsg(object t)
        {
            string target = t.GetType().Name;
            Console.WriteLine($"There isn't any {target} in this room.");
        }

        public void BattleReport()
        {
            Console.WriteLine($"Player: {player.Health} HP // Enemy: {player.Room.Enemy.Health} HP");
        }

        public void VictoryMsg()
        {
            Console.WriteLine("You did it! You escaped the dungeon!");
        }

        public void NoExitMsg()
        {
            Console.WriteLine("The exit is not in this room.");
        }

        public void GaveUpMsg()
        {
            Console.WriteLine("You gave up and couldn't reach the end.");
        }

        public void ConfirmMsg()
        {
            Console.Write("Press any Key to continue...");
            Console.ReadKey(true);
            Console.WriteLine("\n");
        }
    }
}