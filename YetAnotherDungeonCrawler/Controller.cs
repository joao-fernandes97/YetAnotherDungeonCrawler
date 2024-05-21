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

                view.ConfirmMsg();
                
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
                    case "West":
                    case "South":
                    case "East":
                        if(player.HasValidTarget())
                        {
                            view.EnemyMsg();
                        }
                        else if(!player.Move(option, dungeon))
                        {
                            view.NoPathFoundMsg();
                        }
                        break;
                    case "Exit":
                        if (currentRoom.IsExit)
                        {
                            view.VictoryMsg();
                            end = true;
                        }
                        else
                        {
                            view.NoExitMsg();
                        }
                        break;
                    case "Give Up":
                        view.GaveUpMsg();
                        end = true;
                        break;
                    default:
                        view.InvalidOption();
                        break;
 
                }

                view.ConfirmMsg();
        
            }
               
        }
    }
}