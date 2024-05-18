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
            using StreamReader sr = new StreamReader("Rooms.txt");
            List<Room> roomList = new List<Room>();

            while ((line=sr.ReadLine()) != null)
            {
                string[] roomProps = line.Split(';');
                bool enemy = roomProps[0] == "true";
                Item item = Enum.Parse<Item>(roomProps[1]);

                int[] connectedRoomIds = new int[4];
                
                for (int i = 0; i < 4; i++)
                {
                    connectedRoomIds[i] = int.Parse(roomProps[2].Split(',')[i]);
                }

                bool isExit = roomProps[3] == "true";


                roomList.Add(new Room(enemy, item, connectedRoomIds, isExit));
            }

            return roomList;
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