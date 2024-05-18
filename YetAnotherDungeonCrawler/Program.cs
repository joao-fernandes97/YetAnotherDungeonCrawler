using System;

namespace YetAnotherDungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller= new Controller();
            View view = new View();

            controller.Start(view);
        }
    }
}
