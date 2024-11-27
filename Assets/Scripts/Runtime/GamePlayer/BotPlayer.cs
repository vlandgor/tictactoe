using Runtime.BotService;
using Runtime.Marks;

namespace Runtime.GamePlayer
{
    public class BotPlayer : IPlayer
    {
        public string Name => "Bot";   
        
        public Mark Mark { get; }
        public BotLevel BotLevel { get; }
        
        public BotPlayer(Mark mark, BotLevel botLevel)
        {
            Mark = mark;
            BotLevel = botLevel;
        }
    }
}