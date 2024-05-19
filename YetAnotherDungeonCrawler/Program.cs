using System;

namespace YetAnotherDungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player= new Player(10,2);
            
            Controller controller= new Controller(player);
            View view = new View();

            controller.Start(view);
        }
    }
}
