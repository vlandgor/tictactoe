using Runtime.BotService;
using Runtime.Tokens;

namespace Runtime.GamePlayer
{
    public class BotPlayer : IPlayer
    {
        public string Name => "Bot";   
        
        public Token Token { get; }
        public BotLevel BotLevel { get; }
        
        public BotPlayer(Token token, BotLevel botLevel)
        {
            Token = token;
            BotLevel = botLevel;
        }
    }
}