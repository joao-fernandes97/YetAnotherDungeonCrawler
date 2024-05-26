namespace YetAnotherDungeonCrawler
{
    public class Controller
    {
        private Player player;
        private Dungeon dungeon;
        private Room currentRoom;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"> The character the user controls </param>
        public Controller(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// The main game loop
        /// </summary>
        /// <param name="view"> Interface of what will be displayed </param>
        public void Start(IView view)
        {
            dungeon = new Dungeon(view.ReadRoomConfig());
            dungeon.PopulateRooms();
            currentRoom = dungeon.GetStartingRoom();
            player.SetStartingRoom(currentRoom);

            view.WelcomeMsg();
            view.ReadDungeonMap();

            string option;

            bool end = false;

            while (player.Health > 0 && end != true)
            {
                view.PrintRoomDescription(currentRoom);
                
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
                        if(player.HasValidTarget())
                        {
                            view.EnemyMsg();
                        }
                        else if (currentRoom.IsExit)
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