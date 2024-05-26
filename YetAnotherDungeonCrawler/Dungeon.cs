using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Holds a List of Rooms representing the dungeon and methods
    /// to get or manipulate data regarding the dungeon as a whole 
    /// </summary>
    public class Dungeon
    {
        readonly List<Room> rooms;

        public Dungeon(List<Room> rooms)
        {
            this.rooms = rooms;
        }

        /// <summary>
        /// Runs at the beginning of the game loop to populate
        /// rooms that have enemies with the Enemies themselves
        /// </summary>
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

        /// <summary>
        /// Runs at the beginning of the game loop to set the starting
        /// room
        /// </summary>
        /// <returns>The first room on the list</returns>
        public Room GetStartingRoom()
        {
            return rooms[0];
        }

        /// <summary>
        /// Returns a Room of the dungeon based on its ID
        /// </summary>
        /// <param name="id">The ID of the Room we want</param>
        /// <returns>The Room with a matching ID,
        /// null if one isn't found</returns>
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