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
        private Room currentRoom;
        
        public Controller(Player player)
        {
            this.player = player;
        }

        public void Start(View view)
        {
            dungeon = new Dungeon(view.ReadRoomConfig());
            dungeon.PopulateRooms();
            currentRoom = dungeon.GetStartingRoom();
            player.SetStartingRoom(currentRoom);
            //view.PrintRoomList(view.ReadRoomConfig());

            view.WelcomeMsg();

            string option;

            bool end = false;

            while (player.Health >= 0 && end != true)
            {
                view.PrintRoomDescription(currentRoom);
                //might want to append a message if there is a monster or item in the room
                if(player.HasValidTarget())
                {
                    view.TargetMsg(currentRoom.Enemy);
                }
                if(player.Room.HasItem)
                {
                    view.TargetMsg(currentRoom.Item);
                }

                option = view.ReadOption();
                switch (option)
                {
                    case "Attack":
                        //if theres an enemy with hp above 0
                        if(player.HasValidTarget())
                        {
                            player.Attack(currentRoom.Enemy);
                            currentRoom.Enemy.Attack(player);
                        }
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
                        if(player.Heal())
                        {
                            view.HealthRestoredMsg();
                            //if there's an enemy present
                            if(currentRoom.Enemy.Health > 0)
                            {
                                //enemy attack
                                currentRoom.Enemy.Attack(player);
                            }
                        }
                        else{
                            //print healing error
                            view.NoHealsMsg();
                        }
                        break;
                    case "North":
                        //if there's an enemy present
                        //enemy present msg
                        //elseif player.Room.Exits.North exists
                        //move player to that room id
                        //else
                        //print no path found msg
                        break;
                    case "West":
                        //if there's an enemy present
                        //enemy present msg
                        //elseif player.Room.Exits.West exists
                        //move player to that room id
                        //else
                        //print no path found msg
                        break;
                    case "South":
                        //if there's an enemy present
                        //enemy present msg
                        //elseif player.Room.Exits.South exists
                        //move player to that room id
                        //else
                        //print no path found msg
                        break;
                    case "East":
                        //if there's an enemy present
                        //enemy present msg
                        //elseif player.Room.Exits.East exists
                        //move player to that room id
                        //else
                        //print no path found msg
                        break;
                    case "Exit":
                        if (currentRoom.IsExit)
                        {
                        //display victory message
                        end = true;
                        }
                        else
                        {
                        //print no exit msg
                        }
                        break;
                    case "Give Up":
                        //terminate loop
                        //print gave up msg
                        end = true;
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