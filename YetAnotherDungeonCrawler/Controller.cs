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

        public void Start(IView view)
        {
            dungeon = new Dungeon(view.ReadRoomConfig());
            dungeon.PopulateRooms();
            currentRoom = dungeon.GetStartingRoom();
            player.SetStartingRoom(currentRoom);
            view.PrintRoomList(view.ReadRoomConfig());

            view.WelcomeMsg();
            view.ReadDungeonMap();

            string option;

            bool end = false;

            while (player.Health >= 0 && end != true)
            {
                view.PrintRoomDescription(currentRoom);
                //might want to append a message if there is a monster or item in the room

                //view.ConfirmMsg();
                
                if(player.HasValidTarget())
                {
                    view.EnemyMsg();
                }
                if(player.Room.Item != Item.None)
                {
                    view.ItemMsg(currentRoom.Item);
                }

                option = view.ReadOption();
                switch (option)
                {
                    case "attack":
                        //if theres an enemy with hp above 0
                        if(player.HasValidTarget())
                        {
                            player.Attack(currentRoom.Enemy);
                            currentRoom.Enemy.Attack(player);
                            view.BattleReport();
                        }else
                        {
                            view.NoTargetMsg(currentRoom.Enemy);
                        }
                        //player Attack
                        //enemy Attack
                        //print result
                        //else
                        //print no target msg
                        break;
                    case "pick up":
                        if(currentRoom.Item != Item.None)
                        {
                            player.PickUpItem();
                            if(player.HasValidTarget())
                            {
                                //enemy attack
                                currentRoom.Enemy.Attack(player);
                                view.BattleReport();
                            }
                        }else
                        {
                            view.NoTargetMsg(Item.HealthPotion);
                        }
                        break;
                    case "heal":
                        if(player.Heal())
                        {
                            view.HealthRestoredMsg();
                            //if there's an enemy present
                            if(player.HasValidTarget())
                            {
                                //enemy attack
                                currentRoom.Enemy.Attack(player);
                                view.BattleReport();
                            }
                        }
                        else{
                            //print healing error
                            view.NoHealsMsg();
                        }
                        break;
                    case "north":
                    case "west":
                    case "south":
                    case "east":
                        if(player.HasValidTarget())
                        {
                            view.EnemyMsg();
                        }
                        else if(!player.Move(option, dungeon))
                        {
                            view.NoPathFoundMsg();
                        }
                        currentRoom = player.Room;
                        break;
                    case "exit":
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
                    case "give up":
                        view.GaveUpMsg();
                        end = true;
                        break;
                    case "map":
                        view.ReadDungeonMap();
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