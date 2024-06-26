using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public interface IView
    {       
        public string ReadOption();

        public void WelcomeMsg();

        public void InvalidOption();

        public void PrintRoomDescription(Room room);

        public void ReadDungeonMap();

        public List<Room> ReadRoomConfig();

        public void PrintRoomList(List<Room> roomList);

        public void HealthRestoredMsg();

        public void NoHealsMsg();

        public void NoPathFoundMsg();
        
        public void EnemyMsg();

        public void ItemMsg(Item item);

        public void NoTargetMsg(object t);

        void BattleReport();

        void VictoryMsg();

        void NoExitMsg();

        void GaveUpMsg();

        void ConfirmMsg();
    }
}