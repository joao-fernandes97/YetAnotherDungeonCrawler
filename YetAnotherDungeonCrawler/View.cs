using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class View
    {
        public View(){}
        
        public void ReadInput()
        {

        }
        public void PrintOutput()
        {

        }

        public void ReadDungeonMap()
        {

        }

        public List<Room> ReadRoomConfig()
        {
            string line;
            string directory = Directory.GetCurrentDirectory();
            string filename = "Rooms.txt";
            string fullPath = Path.Combine(directory, filename);

            if(File.Exists(fullPath))
            {
                using StreamReader sr = new StreamReader(fullPath);

                List<Room> roomList = new List<Room>();

                while ((line=sr.ReadLine()) != null)
                {
                    string[] roomProps = line.Split(';');
                    int id = int.Parse(roomProps[0]);
                    bool enemy = roomProps[1] == "true";
                    Item item = Enum.Parse<Item>(roomProps[2]);

                    int[] connectedRoomIds = new int[4];
                
                    for (int i = 0; i < 4; i++)
                    {
                        connectedRoomIds[i] = int.Parse(roomProps[3].Split(',')[i]);
                    }

                    bool isExit = roomProps[4] == "true";


                    roomList.Add(new Room(id, enemy, item, connectedRoomIds, isExit));
                }

                return roomList;
            }
            
            
            Console.WriteLine($"File '{filename}' not found in directory '{directory}'.");
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