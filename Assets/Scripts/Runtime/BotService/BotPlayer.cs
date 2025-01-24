using Runtime.GamePlayer;

namespace Runtime.BotService
{
    public class BotPlayer : IPlayer
    {
        public string Name { get; }
        public int SetIndex { get; }
        
        public BotPlayer(int setIndex, string name)
        {
            SetIndex = setIndex;
            Name = name;
        }
    }
}