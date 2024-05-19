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
        public View(){}
        
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
    }
}