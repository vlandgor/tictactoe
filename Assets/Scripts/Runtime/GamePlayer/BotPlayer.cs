using Runtime.BotService;
using Runtime.Tokens;

namespace Runtime.GamePlayer
{
    public class BotPlayer : IPlayer
    {
        public string Name => "Bot";
        public int SetIndex { get; }

        public BotLevel BotLevel { get; }
        
        public BotPlayer(int setIndex, BotLevel botLevel)
        {
            BotLevel = botLevel;
        }
    }
}