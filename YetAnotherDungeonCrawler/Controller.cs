using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Controller
    {
        private Player player;
        private Dungeon dungeon;
        
        public Controller(Player player)
        {
            this.player = player;
        }

        public void Start(View view)
        {
            dungeon = new Dungeon(view.ReadRoomConfig());
            dungeon.PopulateRooms();
            player.SetStartingRoom(dungeon.GetStartingRoom());
            //view.PrintRoomList(view.ReadRoomConfig());
            view.WelcomeMsg();

            string option;

            while (player.Health != 0)
            {
                view.PrintRoomDescription(player.Room);
                //might want to append a message if there is a monster or item in the room

                option = view.ReadOption();
                switch (option)
                {
                    case "Attack":
                        //only if theres an enemy with hp above 0
                        //player Attack
                        //enemy Attack
                        //print result
                        //else
                        //print no target msg
                        break;
                    case "Pick Up":
                        //only if theres an item in the room
                        //player PickUpItem
                        //remove item from room
                        //else
                        //print no item msg
                        break;
                    case "Heal":
                        //only if player has Item.HealingPotion in inv
                        //player.Heal
                        //if there's an enemy present
                        //enemy attack
                        //else
                        //print no healing items msg
                        break;
                    case "North":
                        //if player.Room.Exits.North exists
                        //move player to that room id
                        //else
                        //print no path found msg
                        break;
                    case "West":
                        //if player.Room.Exits.West exists
                        //move player to that room id
                        //else
                        //print no path found msg
                        break;
                    case "South":
                        //if player.Room.Exits.South exists
                        //move player to that room id
                        //else
                        //print no path found msg
                        break;
                    case "East":
                        //if player.Room.Exits.East exists
                        //move player to that room id
                        //else
                        //print no path found msg
                        break;
                    case "Exit":
                        //if player.Room.IsExit
                        //end loop
                        //display victory message
                        //end game
                        //else
                        //print no exit msg
                        break;
                    case "Give Up":
                        //terminate loop
                        //print gave up msg
                        break;
                    default:
                        view.InvalidOption();
                        break;
 
                }

                //view.ConfirmMsg();
        
            }
               
        }
    }
}